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
        public IActionResult GetAllUsers() 
        {
            var users = _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUsersById(int id) 
        { 
            var result = _userRepository.GetById(id);
            return Ok(result);
        }

        [HttpPost("cadastro")]
        public IActionResult CadastrarUsuario([FromBody] User usuario)
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
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            return Ok(_userRepository.Update(id, user));
        }

        //[HttpPut]
        //public IActionResult UpdateUser([FromBody] User user)
        //{

        //}
    }
}
