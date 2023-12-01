using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Services
{
    public class EventBookingRepo : IEventBookingRepo
    {
        private string filepath = @"Data/jsonEventBooking.json";

        public void Addbooking(EventBooking booking)
        {
            throw new NotImplementedException();
        }

        public int CalculateAttendees(Event ev)
        {
            throw new NotImplementedException();
        }

        public void DeleteBooking(EventBooking booking)
        {
            throw new NotImplementedException();
        }

        public List<EventBooking> GetAllbookingByEvent(Event ev)
        {
            throw new NotImplementedException();
        }

        public List<EventBooking> GetAllBookings()
        {
            throw new NotImplementedException();
        }

        public EventBooking GetBooking(int id)
        {
            throw new NotImplementedException();
        }
    }
}
