using LAB_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LAB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly UserTypeRespository _userTypeRespository;
        public UserTypeController()
        {
            _userTypeRespository = new UserTypeRespository();
        }

        [HttpGet]
        public async Task<ActionResult> ListUserType()
        {
            try
            {
                return Ok(await _userTypeRespository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserType(int id)
        {
            try
            {
                return Ok(await _userTypeRespository.GetUserType(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
