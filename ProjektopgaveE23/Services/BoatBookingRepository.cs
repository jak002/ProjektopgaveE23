using ProjektopgaveE23.Helpers;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Services
{
    public class BoatBookingRepository : IBoatBookingRepository
    {
        private string filePath = @"Data\jsonBoatBookings.json";
        public void AddBoatBooking(BoatBooking boatbooking)
        {
            List<BoatBooking> bookings = GetAllBoatBookings();
            List<int> bookingsIds = new List<int>();

            foreach (var b in bookings)
            {
                bookingsIds.Add(b.BookingId);
            }
            if (bookingsIds.Count != 0)
            {
                int start = bookingsIds.Max();
                boatbooking.BookingId = start + 1;
            }
            else
            {
                boatbooking.BookingId = 1;
            }
            bookings.Add(boatbooking);
            JsonFileWriter<BoatBooking>.WriteToJson(bookings, filePath);
        }

        public void DeleteBoatBooking(BoatBooking boatBooking)
        {
            List<BoatBooking> bookings = GetAllBoatBookings();
            bookings.Remove(boatBooking);
            JsonFileWriter<BoatBooking>.WriteToJson(bookings, filePath);
        }

        public List<BoatBooking> GetAllBoatBookings()
        {
            return JsonFileReader<BoatBooking>.ReadJson(filePath);
        }

        public BoatBooking GetBoatBookingById(int id)
        {
            foreach (var book in GetAllBoatBookings())
            {
                if (book.BookingId == id)
                    return book;
            }
            return new BoatBooking();
        }

        public List<BoatBooking> GetBoatBookingByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
