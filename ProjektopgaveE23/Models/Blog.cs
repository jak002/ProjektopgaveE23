namespace ProjektopgaveE23.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Text { get; set; }
        
        public string BlogImage { get; set; }
        
        public DateTime Date { get; set; }

        public string Author { get; set; }



        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            else if (!(obj is Blog)) return false;

            else if (((Blog)obj).Id == this.Id)
                return true;

            return false;
        }

    }
}
