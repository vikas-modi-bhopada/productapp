

namespace BookingApi.Model
{
    public class Booking
    {
        
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string? imgPath { get; set; }
    }
}
