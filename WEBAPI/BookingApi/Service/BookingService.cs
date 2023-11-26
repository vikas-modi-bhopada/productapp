using BookingApi.Model;
using BookingApi.Repository;

namespace BookingApi.Service
{
    public class BookingService : IBookingService
    {
        readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public bool AddToCart(Booking booking)
        {
            return _bookingRepository.AddToCart(booking);
        }

        public bool Delete(DeleteCart deleteCart)
        {
            return _bookingRepository.Delete(deleteCart);
        }

        public List<Booking> GetCartByUserName(string username)
        {
            return _bookingRepository.GetCartByUserName(username);
        }
    }
}
