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
    private readonly IAuthTokenRepository _authTokenRepository;

    public AuthController(IUserRepository userRepository, IAuthTokenRepository authTokenRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException();
        _authTokenRepository = authTokenRepository ?? throw new ArgumentNullException();
    }

    [HttpPost]
    public IActionResult Auth(string userName, string password)

    {
        UserDTO userDTO = new UserDTO(userName, password);

        var user = _userRepository.Get(userDTO.UserName, userDTO.Password);

        if (user != 0)
        {
            object token = TokenService.GenerateToken(userDTO);
            string tokenString = token.ToString();
            _authTokenRepository.AddToken(user, tokenString);

            return Ok(token);
        }
        return BadRequest("UserName or Password invalid");
    }
}
