using API.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Policy = "User")]
[ApiController]
[Route("api/[controller]/[action]")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public class DashboardController : ControllerBase
{
    private readonly IService _service;

    public DashboardController(IService service)
    {
        _service = service;
    }


    [HttpGet("{userId}")]
    public async Task<IActionResult> UserVm(string userId)
    {
        var response = await _service.User.UserVmSR(userId);
        if (response.IsSuccess) return Ok(response.Data);
        return BadRequest(response);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> UserProfileVmSR(string userId)
    {
        var response = await _service.User.ProfileVmSR(userId);

        if (response.IsSuccess) return Ok(response.Data);

        return BadRequest(response);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> UserProfileVm(string userId)
    {
        var userProfileVm = await _service.User.ProfileVm(userId);

        if (userProfileVm != null) return Ok(userProfileVm);


        return BadRequest(new { Message = "User not found" });
    }

    [HttpGet]
    [ApiVersion("1.0")]
    public async Task<ActionResult> Get()
    {
        var response = await _service.User.ApplicationUsersSR();


        return Ok(response.Data);
    }
    
    [HttpGet]
    [ApiVersion("2.0")]
    public async Task<ActionResult> GetV2()
    {
        var response = await _service.User.ApplicationUsersSR();


        return Ok(response.Data);
    }
}