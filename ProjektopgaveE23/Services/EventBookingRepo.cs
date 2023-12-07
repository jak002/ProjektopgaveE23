using ProjektopgaveE23.Helpers;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;
using System.Reflection.Metadata;

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

        public int CalculateAttendees(int eventId)
        {
            List<EventBooking> bookings = GetAllbookingsByEvent(eventId);
            int result = 0;
            foreach (var book in bookings) 
            {
                result = result + book.AttendeesPerBooking;
            }
            return result;
        }

        public void DeleteBooking(EventBooking booking)
        {
            List<EventBooking> bookings = GetAllBookings();
            bookings.Remove(booking);
            JsonFileWriter<EventBooking>.WriteToJson(bookings, filepath);
        }

        public List<EventBooking> GetAllbookingsByEvent(int eventId)
        {
            List<EventBooking > bookings = new List<EventBooking>();
            foreach (var book in GetAllBookings()) 
            { 
                if (book.EventID == eventId)
                {
                    bookings.Add(book);
                }
            }
            return bookings;
        }

        public List<EventBooking> GetBookingByUserAndEvent(String username, int eventId)    
        {
            List<EventBooking> bookings = new List<EventBooking>();
            foreach (var book in GetAllBookings()) 
            { 
                if (book.EventID==eventId && book.Username==username)
                {
                    bookings.Add(book);
                }
            
            }
            return bookings;

        }

        public List<EventBooking> GetAllBookings()
        {
            return JsonFileReader<EventBooking>.ReadJson(filepath);
        }

        public EventBooking GetBooking(int id)
        {
            foreach (var book in GetAllBookings())
            {
                if (book.ID == id)
                    return book;
            }
            return new EventBooking();
        }
    }
}
