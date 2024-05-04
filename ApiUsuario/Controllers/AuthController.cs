using ApiUsuario.Application.DTOs;
using ApiUsuario.Application.Services;
using ApiUsuario.Domain.Model;
using Microsoft.AspNetCore.Mvc;
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
        UserDTO userDTO = new UserDTO(userName, password);

        var user = _userRepository.Get(userDTO.UserName, userDTO.Password);

        if (user == true)
        {
            var token = TokenService.GenerateToken(userDTO);
            return Ok(token);
        }
        return BadRequest("UserName or Password invalid");
    }
}
