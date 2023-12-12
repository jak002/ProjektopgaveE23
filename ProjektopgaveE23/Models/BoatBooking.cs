namespace ProjektopgaveE23.Models
{
    public class BoatBooking
    {
        public int BookingId { get; set; }
        public int BoatId { get; set; }
        public string Username { get; set; }
        public DateTime DateTime { get; set; }
        public int NumberOfHours { get; set; }

        public DateTime EndDateTime { get { return DateTime.AddHours(NumberOfHours * 1.0); } }


       



        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            else if (!(obj is BoatBooking)) return false;

            else if (((BoatBooking)obj).BookingId == this.BookingId) return true;


            return false;
        }

    }
}
