using ApiUsuario.Model;
using ApiUsuario.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuario.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException();
        }

        [HttpPost]
        public IActionResult Add(UserViewModel userViewModel)
        {
            var user = new User(userViewModel.name, userViewModel.cpf, userViewModel.birthdayData, userViewModel.numberPhone, userViewModel.email, userViewModel.password, userViewModel.address, userViewModel.numberHome);

            _userRepository.Add(user);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var user = _userRepository.Get();

            return Ok(user);

        }
    }
}
