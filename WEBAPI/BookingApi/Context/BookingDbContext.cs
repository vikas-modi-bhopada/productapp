
using BookingApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Context
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext()
        {

        }
        public BookingDbContext(DbContextOptions<BookingDbContext> option):base(option)
        {

        }
        public DbSet<Booking> Cart { get; set; }

    }
}
