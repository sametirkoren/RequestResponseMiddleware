using Microsoft.AspNetCore.Mvc;
using Middleware.TestApi.Models;

namespace Middleware.TestApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetUserInfo(int id)
    {
        var user = new UserLoginResponseModel()
        {
            Success = true,
            UserEmail = "sametirkoren@gmail.com"
        };

        return Ok(user);
    }
    
    [HttpPost]
    [Route("loginonly")]
    public IActionResult LoginOnly([FromBody] UserLoginRequestModel model)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Login([FromBody] UserLoginRequestModel model)
    {
        var user = new UserLoginResponseModel()
        {
            Success = true,
            UserEmail = "sametirkoren@gmail.com"
        };

        return Ok(user);
    }
}