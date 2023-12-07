namespace ProjektopgaveE23.Models
{
    public class EventBooking
    {

        public int ID { get; set; }

        public string Username { get; set; }

        public int EventID { get; set; }

        public int AttendeesPerBooking { get; set; }    



        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            else if (!(obj is EventBooking)) return false;

            else if (((EventBooking)obj).ID == this.ID) return true;

            return false;
        }

    }
}
