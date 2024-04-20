using ApiUsuario.Application.ViewModel;
using ApiUsuario.Domain.Model;
using ApiUsuario.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ApiUsuario.Application.DTOs;

namespace ApiUsuario.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    [HttpPost]
    public IActionResult Add(UserViewModel userViewModel)
    {

        var userDTO = new UserDTO(userViewModel.Name, userViewModel.UserName, userViewModel.Cpf, userViewModel.BirthdayData, userViewModel.NumberPhone, userViewModel.Email, userViewModel.Password, userViewModel.Address, userViewModel.NumberHome);
        if (userViewModel.ValidaCpf(userViewModel.Cpf) && userViewModel.IsValidEmail(userViewModel.Email))
        {
            var user = _mapper.Map<User>(userDTO);
            _userRepository.Add(user);
            return Ok();
        }
        else
        {
            return BadRequest("CPF não contem 11 digitos ou E-mail invalido");
        }
    }

    [HttpGet]
    public IActionResult Get()
    {
        var user = _userRepository.Get();


        var userDTO = _mapper.Map<List<UserDTO>>(user); 
        return Ok(userDTO);
    }
}
