using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Interfaces
{
    public interface IEventBookingRepo
    {

        void Addbooking(EventBooking booking);

        List<EventBooking> GetAllBookings();

        EventBooking GetBooking(int id);

        List<EventBooking> GetAllbookingByEvent(Event ev);

        int CalculateAttendees(Event ev);

        void DeleteBooking(EventBooking booking);


    }

}
