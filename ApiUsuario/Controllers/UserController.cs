using ApiUsuario.Application.ViewModel;
using ApiUsuario.Domain.Model;
using ApiUsuario.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ApiUsuario.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException();
    }

    [Authorize]
    [HttpPost]
    public IActionResult Add(UserViewModel userViewModel)
    {
        var user = new User(userViewModel.Name, userViewModel.UserName, userViewModel.Cpf, userViewModel.BirthdayData, userViewModel.NumberPhone, userViewModel.Email, userViewModel.Password, userViewModel.Address, userViewModel.NumberHome);
        
        _userRepository.Add(user);
        return Ok();
    }

    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        var user = _userRepository.Get();

        return Ok(user);

    }
}
