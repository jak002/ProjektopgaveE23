namespace ProjektopgaveE23.Models
{
    public class Event
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Place { get; set; }

        public int Attendees { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Author { get; set; }



        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            else if (!(obj is Event)) return false;

            else if (((Event)obj).Id == this.Id) return true;

            return false;
        }


    }
}
