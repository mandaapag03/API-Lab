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

        [HttpPost("signIn")]
        public IActionResult SignInUser([FromBody] User user)
        {
            try
            {
                _userRepository.Create(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                return Ok(_userRepository.Update(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateUser([FromBody] User user, int id)
        {
            try
            {
                return Ok(_userRepository.Update(user, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("disable/{id}")]
        public IActionResult DisableUser(int id)
        {
            try
            {
                return Ok(_userRepository.Disable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("enable/{id}")]
        public IActionResult EnableUser(int id)
        {
            try
            {
                return Ok(_userRepository.Enable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
