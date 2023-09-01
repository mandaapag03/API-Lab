using LAB_API.Interfaces;
using LAB_API.Model;
using LAB_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController() 
        {
            _userRepository = new UserRepository();
        }

        [HttpGet]
        public IActionResult GetUsuarios() 
        {
            var users = _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpPost("cadastro")]
        public IActionResult CadastrarUsuario(User usuario)
        {
            try
            {
                _userRepository.Create(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {

        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {

        }
    }
}
