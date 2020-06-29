using FlightRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightRegistration.DBContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<UserDetails> UserDetails { get; set; }
        //public DbSet<CarTB> CarTB { get; set; }
        //public DbSet<BookingTB> BookingTB { get; set; }
        //public DbSet<PaymentTB> PaymentTB { get; set; }
        //public DbSet<BankTB> BankTB { get; set; }
        public DbSet<TokenManager> TokenManager { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<AppointmentModel> AppointmentModel { get; set; }
        public DbSet<PassengerModel> PassengerModel { get; set; }
        public DbSet<PassengerAppointmentModel> PassengerAppointmentModel { get; set; }


    }
}
