namespace LAB_API.Model.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking?> CheckBooking(Booking newBooking);
        Task<Booking> GetBooking(int id);
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<Booking> Create(Booking booking);
        Task<bool> Delete(int id);
    }
}
