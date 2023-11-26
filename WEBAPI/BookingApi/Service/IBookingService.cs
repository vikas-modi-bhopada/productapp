using BookingApi.Model;

namespace BookingApi.Service
{
    public interface IBookingService
    {
        bool AddToCart(Booking booking);
        List<Booking> GetCartByUserName(string username);
        bool Delete(DeleteCart deleteCart);
    }
}
