using API.Models.DTO;
using API.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IService _service;

    public AuthController(IService service)
    {
        _service = service;
    }


    [HttpPost]
    public async Task<IActionResult> Login(LogInUserDto logInUserDto)
    {
        var (username, password) = logInUserDto;
        var result = await _service.Auth.LoggedInUserVm(username, password);
        if (result.IsSuccess == false) return BadRequest(result);

        return Ok(result.Data);
    }
    
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _service.Auth.Logout();
        return Ok();
    }
    
}