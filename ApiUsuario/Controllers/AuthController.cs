using Microsoft.AspNetCore.Mvc;
using ApiUsuario.Application.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using ApiUsuario.Domain.Model;
using ApiUsuario.Application.Services;
using ApiUsuario.Application.DTOs;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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

         _userRepository.Get(userDTO.UserName, userDTO.Password);
        
        if (userName == userDTO.UserName  && password == userDTO.Password)
        {
            var token = TokenService.GenerateToken(userDTO);
            return Ok(token);
        }
        return BadRequest("UserName or Password invalid");
    }
}
