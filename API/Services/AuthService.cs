using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Config;
using API.Models.DTO;
using API.Models.Entity;
using API.Models.ViewModel;
using API.Repositories.Interface;
using API.Services.Interface;
using API.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IRepository _repo;
    private readonly AppSettingsExtension _appSettings;

    public AuthService(AppDbContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IRepository repo,
        IOptions<AppSettingsExtension> appSettings, RoleManager<IdentityRole> roleManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _signInManager = signInManager;

        _repo = repo;
        _roleManager = roleManager;
        _appSettings = appSettings.Value;
    }

    public async Task<ServiceResponse<LoggedInUserVm>> LoggedInUserVm(string username, string password)
    {
        var serviceResponse = new ServiceResponse<LoggedInUserVm>();

        try
        {
            var signInResult = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);
            if (signInResult.Succeeded == false)
            {
                serviceResponse.Message = "Invalid username or password";
                serviceResponse.IsSuccess = false;
                return serviceResponse;
            }

            var foundUser = await _repo.UserRepo.ApplicationUserByUsername(username, true, true);


            if (foundUser == null)
            {
                serviceResponse.Message = "No User Found";
                serviceResponse.IsSuccess = false;
                return serviceResponse;
            }

            var userRoles = await _userManager.GetRolesAsync(foundUser);
            var token = AuthenticateUser(foundUser, userRoles);


            var loggedInUserVm = new LoggedInUserVm
            {
                Id = foundUser.Id,
                Username = foundUser.UserName,
                Roles = userRoles.ToList(),
                Token = token,
                Settings = new UserSettingsVm
                {
                    FavoriteLinks = foundUser.UserSettings.FavoriteLinks.Select(f => new FavoriteLinkVm
                    {
                        Name = f.Name,
                        Link = f.Link
                    }).ToList(),
                    IsContactEmailShowing = foundUser.UserSettings.IsContactEmailShowing,
                    IsContactNumberShowing = foundUser.UserSettings.IsContactNumberShowing
                },
                Image = string.IsNullOrEmpty(foundUser.UserProfile.Image) ? "" : foundUser.UserProfile.Image
            };


            // var loggedInUser = new LoggedInUserVm(foundUser.Id, foundUser.UserName, userRoles.ToList(), "12321",
            //     foundUser.UserProfile.Image);

            serviceResponse.Data = loggedInUserVm;
        }
        catch (Exception e)
        {
            serviceResponse.Message = e.Message;
            serviceResponse.IsSuccess = false;
        }

        return serviceResponse;
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<ServiceResponse<bool>> Register(RegisterUserDto registerUserDto)
    {
        var serviceResponse = new ServiceResponse<bool>();
        if (registerUserDto.RegistrationCode != "2006" && registerUserDto.RegistrationCode != "ADMIN2006" && registerUserDto.RegistrationCode != "TestUser")
        {
            serviceResponse.IsSuccess = false;
            serviceResponse.Message = "Incorrect Registration Code...";
            return serviceResponse;
        }

        try
        {
            var newUser = new ApplicationUser
            {
                UserName = registerUserDto.UserName, Email = registerUserDto.Email, PhoneNumber = "", FullName = registerUserDto.FirstName + " " + registerUserDto.LastName
            };
            var result = await _userManager.CreateAsync(newUser, registerUserDto.Password);

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(error => error.Description).ToList();
                serviceResponse.Errors = errorList;
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Error during Registration";
                return serviceResponse;
            }

            var newProfile = new UserProfile
            {
                UserId = newUser.Id,
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                User = newUser,
                Handicap = 0,
                Image = "https://sbassets.blob.core.windows.net/default/defaultProfileImg.svg",
                CreatedOn = DateTime.Now,
            };


            var favoriteLinks = new List<FavoriteLink>
            {
                new()
                {
                    Link = "/dashboard",
                    Name = "Dashboard",
                },
                new()
                {
                    Link = "/bets",
                    Name = "Bets",
                },

                new()
                {
                    Link = "/contacts",
                    Name = "Contacts",
                }
            };


            var newSettings = new UserSettings { UserId = newUser.Id, FavoriteLinks = favoriteLinks };
            newUser.UserProfile = newProfile;
            newUser.UserSettings = newSettings;

            string roleName;

            // Check if Admin or User role exists before adding a user to that role
            if (registerUserDto.RegistrationCode is "ADMIN2006" or "2006")
            {
                roleName = registerUserDto.RegistrationCode == "ADMIN2006" ? "Admin" : "User";
            }
            else
            {
                roleName = "TestUser";
            }

            var doesRoleExist = await _roleManager.RoleExistsAsync(roleName);
            if (doesRoleExist == false)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }

            await _userManager.AddToRoleAsync(newUser, roleName);


            await _dbContext.SaveChangesAsync();
            serviceResponse.Data = true;
        }
        catch (Exception e)
        {
            serviceResponse.Message = e.Message;
            serviceResponse.IsSuccess = false;
        }

        return serviceResponse;
    }


    private string? AuthenticateUser(ApplicationUser? user, IEnumerable<string> userRoles)
    {
        if (user == null) return null;


        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Id)
            }),

            // Issuer = api website that issued the token
            // Audience - who the token is supposed to be read by
            // Expires = DateTime.Now.AddMinutes(1),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        foreach (var userRole in userRoles)
        {
            tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, userRole));
        }

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var userToken = tokenHandler.WriteToken(token);

        return userToken;
    }
}