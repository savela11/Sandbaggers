using System.Security.Claims;
using System.Text;
using API.Models;
using API.Models.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.IdentityModel.Tokens;

namespace API.Config;

public static class StartupExtensions
{
    public static void ConfigureIdentityOptions(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
        });
    }


    private static bool Validate(DateTime? notBefore, DateTime? expires, SecurityToken tokenToValidate, TokenValidationParameters @param)
    {
        return expires != null && expires > DateTime.UtcNow;
    }

    public static void ConfigureJwtAuthentication(this WebApplicationBuilder builder)
    {
        var appSettingsSection = builder.Configuration.GetSection("AppSettings");
        builder.Services.Configure<AppSettingsExtension>(appSettingsSection);
        var appSettings = appSettingsSection.Get<AppSettingsExtension>();

        var key = Encoding.ASCII.GetBytes(appSettings.Secret);

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;

            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                LifetimeValidator = Validate,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });
    }


    public static void ConfigureIdentityService(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Stores.MaxLengthForKeys = 128;
        }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
    }

    public static void ConfigureGlobalAuthorizationPolicy(this IServiceCollection services)
    {
        services.AddMvc(o =>
        {
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            o.Filters.Add(new AuthorizeFilter(policy));
        });
    }

    public static void ConfigureApiAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(o =>
        {
            o.AddPolicy("User", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole("User");
            });

            o.AddPolicy("Admin", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole("Admin");
            });
            o.AddPolicy("apiPolicy", b =>
            {
                b.RequireAuthenticatedUser();
                b.RequireClaim(ClaimTypes.Role, "Access.Api");
                b.AuthenticationSchemes = new List<string> { JwtBearerDefaults.AuthenticationScheme };
            });
        });
    }

    /// <summary>
    /// Configure the API versioning properties of the project, such as return headers, version format, etc.
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            // ReportApiVersions will return the "api-supported-versions" and "api-deprecated-versions" headers.

            options.ReportApiVersions = true;

            // Set a default version when it's not provided,
            // e.g., for backward compatibility when applying versioning on existing APIs
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);

            options.ApiVersionReader = ApiVersionReader.Combine(
                // The Default versioning mechanism which reads the API version from the "api-version" Query String paramater.
                new QueryStringApiVersionReader("api-version"),
                // Use the following, if you would like to specify the version as a custom HTTP Header.
                new HeaderApiVersionReader("Accept-Version"),
                // Use the following, if you would like to specify the version as a Media Type Header.
                new MediaTypeApiVersionReader("api-version")
            );
        });
    }
}