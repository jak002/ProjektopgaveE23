using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Interfaces
{
    public interface IBoatBookingRepository
    {
        List<BoatBooking> GetAllBoatBookings();
        void AddBoatBooking(BoatBooking boatbooking);
        BoatBooking GetBoatBookingById(int id);
        List<BoatBooking> GetBoatBookingByUserId(int userId);

        List<BoatBooking> GetAllBookingsByBoatId(int boatId);

        bool CheckAvailability(int boatId, DateTime start, DateTime end);
        void DeleteBoatBooking(BoatBooking boatBooking);

    }
}
