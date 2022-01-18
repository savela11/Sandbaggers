using API.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Areas.Admin;

[Area("Admin")]
[Authorize(Policy = "Admin")]
[ApiController]
[Route("api/[area]/[controller]/[action]")]
[Route("api/v{version:apiVersion}/[area]/[controller]/[action]")]
public class RoleController : ControllerBase
{
    private readonly IService _service;

    public RoleController(IService service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<IActionResult> List()
    {
        var result = await _service.Role.List();

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> ListWithUsers()
    {
        var listOfRolesWithUsers = await _service.Role.ListWithUsers();

        return Ok(listOfRolesWithUsers);
    }
}