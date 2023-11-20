using LAB_API.Model;
using LAB_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LAB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingRepository _bookingRepository;
        private readonly PaymentBoletoApi _paymentBoletoApi;
        private readonly UserRepository _userRepository;
        private readonly LabRepository _labRepository;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _bookingRepository = new BookingRepository();
            _userRepository = new UserRepository();
            _paymentBoletoApi = new PaymentBoletoApi(httpClientFactory);
            _labRepository = new LabRepository();
        }

        private async Task<Booking> CreateBooking(int userId, int labId)
        {
            var booking = new Booking()
            {
                UserId = userId,
                LabId = labId,
                Date = DateTime.Now
            };
            return await _bookingRepository.Create(booking);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAllBookings()
        {
            try
            {
                var result = await _bookingRepository.GetAllBookings();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("verify")]
        public async Task<ActionResult> VerifyBooking(int userId, int labId)
        {
            try
            {
                var lab = _labRepository.GetLabById(labId);
                if (!lab.IsActive)
                    throw new Exception("This lab is not active now");

                var booking = new Booking()
                {
                    UserId = userId,
                    LabId = labId,
                    Date = DateTime.Now
                };

                var result = await _bookingRepository.CheckBooking(booking);

                NullOrEmptyVariable<Booking>.ThrowIfNull(result, "Não há reservas feitas para esse lab");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            try
            {
                var result = await _bookingRepository.GetBooking(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("aluno/{userId}/new/{labId}")]
        public async Task<ActionResult<Booking>> CreateNewBookingAluno([FromRoute] int userId, [FromRoute] int labId, [FromBody] BoletoInfo boleto)
        {
            if (boleto.status != "approved")
                return BadRequest("Não foi possível fazer a reserva, por favor tente mais tarde.");

            try
            {
                var result = await CreateBooking(userId, labId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("professor/{userId}/new/{labId}")]
        public async Task<ActionResult<Booking>> CreateNewBookingProfessor([FromRoute] int userId, [FromRoute] int labId)
        {
            try
            {
                var user = _userRepository.GetById(userId);
                if (user.UserType.Description != "Professor")
                    throw new Exception("This user isn't a Professor");

                var result = await CreateBooking(userId, labId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("payment/{userId}")]
        public async Task<ActionResult<BoletoInfo>> PayBoleto([FromRoute] int userId, [FromBody] string cdBoleto)
        {
            try
            {
                var user = _userRepository.GetById(userId);
                if (user.UserType.Description != "Aluno")
                    throw new Exception("This user isn't an Aluno");

                var result = await _paymentBoletoApi.PayBoleto(cdBoleto, userId);
                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]
        public async Task<ActionResult<bool>> DeleteBooking(int id)
        {
            try
            {
                var result = await _bookingRepository.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
