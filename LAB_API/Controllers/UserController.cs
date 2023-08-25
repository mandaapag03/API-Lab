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

        [HttpPost]
        public User? CadastrarUsuario(User usuario)
        {
            _userRepository.Create(usuario);
            return null;
        }
    }
}
