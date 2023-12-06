using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Interfaces
{
    public interface IBoatBookingRepository
    {
        List<BoatBooking> GetAllBoatBookings();
        void AddBoatBooking(BoatBooking boatbooking);
        BoatBooking GetBoatBookingById(int id);
        List<BoatBooking> GetBoatBookingByUserId(string username);

        void DeleteBoatBooking(BoatBooking boatBooking);

    }
}
