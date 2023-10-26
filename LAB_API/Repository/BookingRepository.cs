using LAB_API.Model;
using LAB_API.Model.Interfaces;
using LAB_API.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace LAB_API.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class BookingRepository : IBookingRepository
    {
        private readonly DataBaseContext _context;

        /// <summary>
        /// 
        /// </summary>
        public BookingRepository()
        {
            _context = new DataBaseContext();
        }

        public async Task<Booking?> CheckBooking(Booking newBooking)
        {
            var result = await _context.Bookings
                .Where(x => x.LabId == newBooking.LabId)
                //.Where(x => x.Date.Day == newBooking.Date.Day)
                .Where(x => x.Date >= newBooking.Date && x.Date <= newBooking.Date.AddHours(1))
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<Booking> Create(Booking booking)
        {
            try
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                var id = await _context.Bookings.MaxAsync(x => x.Id);
                return NullOrEmptyVariable<Booking>.ThrowIfNull(
                    await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id), "Booking create error");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var booking = await GetBooking(id);
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            return await _context.Bookings
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Booking> GetBooking(int id)
        {
            var booking = await _context.Bookings
                .Include(x => x.User)
                .Include(x => x.Lab)
                .FirstOrDefaultAsync(x => x.Id == id);
            return NullOrEmptyVariable<Booking>.ThrowIfNull(booking, "Booking does not exists");
        }
    }
}
