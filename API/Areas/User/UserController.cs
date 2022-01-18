using API.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Areas.User;

[Area("User")]
// [Authorize(Policy = "User")]
[AllowAnonymous]
[ApiController]
[Route("api/[area]/[controller]/[action]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpGet("{userId}")]
    public async Task<IActionResult> UserProfileVmSR(string userId)
    {
        var response = await _userService.ProfileVmSR(userId);

        if (response.IsSuccess) return Ok(response.Data);

        return BadRequest(response);
    }
}