using LAB_API.Model;
using LAB_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAB_API.Controllers
{
    /// <summary>
    /// Controller of Lab Entity
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LabController : ControllerBase
    {
        private LabRepository _labRepository;

        /// <summary>
        /// Constructor method of controler lab
        /// </summary>
        public LabController()
        {
            _labRepository = new LabRepository();
        }

        /// <summary>
        /// Get all registers of lab
        /// </summary>
        [HttpGet]
        public IActionResult GetAllLabs()
        {
            try
            {
                return Ok(_labRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get a lab by your code
        /// </summary>
        [HttpGet("{codeLab}")]
        public IActionResult GetLabByCode(string codeLab)
        {
            try
            {
                return Ok(_labRepository.GetLabByLabCode(codeLab));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create a new lab in database
        /// </summary>
        [HttpPost("signIn")]
        public IActionResult SignInLab(Lab lab)
        {
            try
            {
                return Ok(_labRepository.Create(lab));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update proporties of a lab
        /// </summary>
        [HttpPut("update/{id}")]
        public IActionResult UpdateLab([FromBody] Lab lab, [FromRoute] int id)
        {
            try
            {
                lab.Id = id; 
                return Ok(_labRepository.Update(lab));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Disable a lab
        /// </summary>
        [HttpPut("disable/{codeLab}")]
        public IActionResult DisableLab([FromRoute]string codeLab)
        {
            try
            {
                return Ok(_labRepository.Disable(codeLab));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Enable a lab
        /// </summary>
        [HttpPut("enable/{codeLab}")]
        public IActionResult EnableLab([FromRoute] string codeLab)
        {
            try
            {
                return Ok(_labRepository.Enable(codeLab));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
