using ApiUsuario.Application.ViewModel;
using ApiUsuario.Domain.Model;
using ApiUsuario.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ApiUsuario.Application.DTOs;
using System.Net;
using System.Xml.Linq;
using System.Net.Mail;
using ApiUsuario.Application.Services;

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


    [HttpPost("register")]
    public IActionResult Add(UserViewModel userViewModel)
    {

        var userDTO = new UserDTO(userViewModel.Name, userViewModel.UserName, userViewModel.Cpf, userViewModel.BirthdayData, userViewModel.NumberPhone, userViewModel.Email, userViewModel.Password, userViewModel.Address, userViewModel.NumberHome);
        if (userViewModel.ValidaCpf(userViewModel.Cpf) && userViewModel.IsValidEmail(userViewModel.Email))
        {
            var user = _mapper.Map<User>(userDTO);
            _userRepository.Add(user);
            return Ok("Usuário cadastrado com sucesso");
        }
        else
        {
            return BadRequest("CPF não contem 11 digitos ou E-mail invalido");
        }
    }
    //Reset de senha por e-mail
    [HttpPost("RecuperarSenha")]
    public IActionResult Get(string userName, string email, long cpf)
    {
        var userDTO = new UserDTO(userName, cpf, email);
        var user = _userRepository.GetResetEmail(userDTO.UserName, userDTO.Cpf, userDTO.Email);

        if (MailService.Send(email, user))
            return Ok("E-Mail enviado com sucesso");
        else
            return NotFound();
    }
    //Acesso só com perfil Adm
    [HttpGet("{userId}")]
    public IActionResult Get(int userId)
    {
        var userDTO = new UserDTO(userId);
        var user = _userRepository.GetId(userDTO.UsuarioId);

        if (userId == null)
        {
            return NotFound();
        }
        var userDto = _mapper.Map<List<UserDTO>>(user);
        return Ok(userDto);
    }

    //Retorna Profile
    [HttpGet("profile")]
    public IActionResult Get(string userName)
    {

        var user = _userRepository.GetProfile(userName);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpGet("user-profile")]
    public IActionResult GetUser(string userName)
    {
        var user = _userRepository.GetUser(userName);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);

    }

}