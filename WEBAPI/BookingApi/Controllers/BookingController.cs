using BookingApi.Model;
using BookingApi.Service;
using Microsoft.AspNetCore.Mvc;



namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ExceptionHandler]
    public class BookingController : Controller
    {
        readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;   
        }
        
        [Route("AddToCart")]
        [HttpPost]
        public IActionResult AddToCart(Booking booking)
        {
            bool AddCartStatus = _bookingService.AddToCart(booking);
            return Ok(AddCartStatus);
        }
        [Route("GetCartByUserName")]
        [HttpGet]
        public IActionResult GetCartByUserName(string username)
        {
            List<Booking> booking = _bookingService.GetCartByUserName(username);
            return Ok(booking);
        }

        [Route("DeleteProduct")]
        [HttpDelete]

        public ActionResult Delete(DeleteCart deleteCart)
        {
            bool DeleteProductStatus = _bookingService.Delete(deleteCart);
            return Ok(DeleteProductStatus);
        }


    }
}
