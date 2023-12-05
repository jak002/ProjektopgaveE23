using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Interfaces
{
    public interface IEventBookingRepo
    {

        void Addbooking(EventBooking booking);

        List<EventBooking> GetAllBookings();

        EventBooking GetBooking(int id);

        List<EventBooking> GetAllbookingsByEvent(int eventId);

        int CalculateAttendees(int eventId);

        void DeleteBooking(EventBooking booking);

        public List<EventBooking> GetBookingByUser(String username, int eventId);


    }

}
