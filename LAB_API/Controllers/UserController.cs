using LAB_API.Interfaces;
using LAB_API.Model;
using LAB_API.Repository;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// This method makes authentication of an user
        /// </summary>
        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] Credencials credencials)
        {
            var user = _userRepository.Login(credencials);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenRepository.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }

        /// <summary>
        /// Get all users 
        /// </summary>
        [HttpGet]
        public IActionResult GetAllUsers() 
        {
            var users = _userRepository.GetAllUsers();
            return Ok(users);
        }

        /// <summary>
        /// Get an specific user by your Id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetUsersById(int id) 
        { 
            var result = _userRepository.GetById(id);
            return Ok(result);
        }

        /// <summary>
        /// Registrate an user
        /// </summary>
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

        /// <summary>
        /// Updates an user
        /// </summary>
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

        /// <summary>
        /// Updates an user by your Id
        /// </summary>
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

        /// <summary>
        /// Disable an user
        /// </summary>
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

        /// <summary>
        /// Enable an user
        /// </summary>
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
