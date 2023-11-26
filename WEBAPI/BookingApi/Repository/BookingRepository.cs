using BookingApi.Context;
using BookingApi.Model;

namespace BookingApi.Repository
{
    public class BookingRepository : IBookingRepository
    {
        readonly BookingDbContext _bookingDbContext;

      public BookingRepository(BookingDbContext bookingDbContext)
        {
            _bookingDbContext = bookingDbContext;
        }

        public bool AddToCart(Booking booking)
        {

            _bookingDbContext.Cart.Add(booking);
            return _bookingDbContext.SaveChanges() == 1 ? true : false;
        }

        public bool Delete(DeleteCart deleteCart)
        {
           
           Booking? booking =  _bookingDbContext.Cart.Where(c => (c.UserName == deleteCart.UserName && c.ProductId == deleteCart.ProductId)).FirstOrDefault();
            if (booking != null)
           _bookingDbContext.Cart.Remove(booking);
            return _bookingDbContext.SaveChanges() == 1 ? true : false;
        }
        
        

        public List<Booking> GetCartByUserName(string? username)
        {
            return _bookingDbContext.Cart.Where(c => c.UserName == username).ToList();
        }
        
    }
}
