using ProjektopgaveE23.Helpers;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Services
{
    public class EventBookingRepo : IEventBookingRepo
    {
        private string filepath = @"Data/jsonEventBooking.json";

        public void Addbooking(EventBooking booking)
        {
            List<int> bookingIds = new List<int>();
            List<EventBooking> bookings = GetAllBookings();

            foreach (var bok in bookings)
            {
                bookingIds.Add(bok.ID);
            }
            if (bookingIds.Count != 0)
            {
                int start = bookingIds.Max();
                booking.ID = start + 1;
            }
            else
            {
                booking.ID = 1;
            }
            bookings.Add(booking);
            JsonFileWriter<EventBooking>.WriteToJson(bookings, filepath);
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
            return JsonFileReader<EventBooking>.ReadJson(filepath);
        }

        public EventBooking GetBooking(int id)
        {
            throw new NotImplementedException();
        }
    }
}
