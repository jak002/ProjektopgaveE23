using ProjektopgaveE23.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ProjektopgaveE23.Models
{
    public class BoatBooking
    {
        public int BookingId { get; set; }
        public int BoatId { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage = "Dato er påkrævet")]
        [CustomData(ErrorMessage ="Dato er ugyldig")]
        public DateTime DateTime { get; set; }
        public int NumberOfHours { get; set; }



       



        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            else if (!(obj is BoatBooking)) return false;

            else if (((BoatBooking)obj).BookingId == this.BookingId) return true;


            return false;
        }

    }
}
