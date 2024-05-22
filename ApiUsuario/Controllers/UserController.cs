using ApiUsuario.Application.DTOs;
using ApiUsuario.Application.ViewModel;
using ApiUsuario.Domain.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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


    [Authorize]
    [HttpPut("RedefinirSenha")]
    public IActionResult Get(string userName, string email, string newPassword)
    {
        var userDTO = new UserDTO(userName, email, newPassword);
        var user = _userRepository.PutResetSenha(userDTO.UserName, userDTO.Email, userDTO.Password);
        return Ok("Reset feito com sucesso");
    }

    //Acesso só com perfil Adm
    [Authorize]
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

    [Authorize]
    [HttpGet("user-profile")]
    public IActionResult GetUser(string userName)
    {
        try
        {
            var user = _userRepository.GetUser(userName);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpPatch("DeleteUser")]
    public IActionResult PutDeleteUser(string userName, string email, string password)
    {
        var user = _userRepository.PutDeleteUser(userName, email, password);
        if (user == true)
        {
            return Ok("Usuário deletado!");
        }
        return BadRequest();
    }

    [HttpPost("register")]
    public IActionResult Add(UserViewModel userViewModel)
    {

        var userView = new User(userViewModel.Name, userViewModel.UserName, userViewModel.Cpf, userViewModel.BirthdayData, userViewModel.NumberPhone, userViewModel.Email, userViewModel.Password, userViewModel.Address, userViewModel.NumberHome);
        if (userViewModel.ValidaCpf(userViewModel.Cpf) && userViewModel.IsValidEmail(userViewModel.Email))
        {
            var user = _mapper.Map<User>(userView);
            _userRepository.Add(user);
            return Ok("Usuário cadastrado com sucesso");
        }
        else
        {
            return BadRequest("CPF não contem 11 digitos ou E-mail invalido");
        }
    }

    //Recuperar senha por e-mail
    [HttpPatch("RecuperarSenhaEmail")]
    public IActionResult Get(string userName, string email, long cpf)
    {
        var userDTO = new UserDTO(userName, cpf, email);
        var recuperarSenha = _userRepository.GetResetEmail(userDTO.UserName, userDTO.Cpf, userDTO.Email);
        return Ok(recuperarSenha);
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
}