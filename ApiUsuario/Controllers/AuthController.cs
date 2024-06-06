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
    private readonly IAccessHistoryRepository _accessHistoryRepository;

    public AuthController(IUserRepository userRepository, IAuthTokenRepository authTokenRepository, IAccessHistoryRepository accessHistoryRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException();
        _authTokenRepository = authTokenRepository ?? throw new ArgumentNullException();
        _accessHistoryRepository = accessHistoryRepository ?? throw new ArgumentNullException();
    }

    [HttpPost]
    public IActionResult Auth(string userName, string password)

    {
        UserDTO userDTO = new UserDTO(userName, password);

        var user = _userRepository.Get(userDTO.UserName, userDTO.Password);
        _accessHistoryRepository.AddAccess(user, userName);
        userDTO.UsuarioId = user;
        if (user == 0)
        {
            return BadRequest("UserName or Password invalid");
        }
        object token = TokenService.GenerateToken(userDTO);
        _authTokenRepository.AddToken(user, token.ToString());
        return Ok(token);
       
    }
}
