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

        public bool CheckAvailability(int boatId, DateTime start, DateTime end)
        {
            foreach(var item in GetAllBookingsByBoatId(boatId))
            {
                if(item.DateTime <= start)
                {
                    if (item.EndDateTime >= start)
                    {
                        return false;
                    }
                }
                else if(item.DateTime <= end)
                {
                    return false;
                }
            }
            return true;
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

        public List<BoatBooking> GetAllBookingsByBoatId(int boatId)
        {
            List<BoatBooking> filteredlist = new List<BoatBooking>();
            foreach(var booking in GetAllBoatBookings())
            {
                if (booking.BoatId == boatId)
                {
                    filteredlist.Add(booking);
                }
            }
            return filteredlist;
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

        public List<BoatBooking> GetCurrentBookings()
        {
            List<BoatBooking> currentList = new List<BoatBooking>();
            foreach(var booking in GetAllBoatBookings())
            {
                if (booking.DateTime <= DateTime.Now && booking.EndDateTime >= DateTime.Now)
                {
                    currentList.Add(booking);
                }
            }
            return currentList;
        }
    }
}
