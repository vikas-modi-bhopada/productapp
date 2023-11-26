using BookingApi.Model;

namespace BookingApi.Repository
{
    public interface IBookingRepository
    {
        bool AddToCart(Booking booking);
        List<Booking> GetCartByUserName(string username);
        bool Delete(DeleteCart deleteCart);
    }
}
