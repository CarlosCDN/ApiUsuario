using Microsoft.AspNetCore.Mvc;
using ApiUsuario.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using ApiUsuario.Domain.Model;
using ApiUsuario.Application.Services;
namespace ApiUsuario.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : Controller
{
    private readonly IUserRepository _userRepository;

    public AuthController(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException();
    }
    [HttpPost]
    public IActionResult Auth(string userName, string password)
    
    {

        var user = _userRepository.Get(userName, password);
        
        if (userName == user.UserName  && password == user.Password)
        {
            var token = TokenService.GenerateToken(user);
            return Ok(token);
        }
        return BadRequest("UserName or Password invalid");
    }
}
