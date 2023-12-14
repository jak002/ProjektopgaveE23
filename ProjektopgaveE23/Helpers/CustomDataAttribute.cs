using System.ComponentModel.DataAnnotations;

namespace ProjektopgaveE23.Helpers
{
    public class CustomDataAttribute : RangeAttribute
    {
        public CustomDataAttribute()
            :base(typeof(DateTime),
                 DateTime.Now.ToString(),
                 DateTime.Now.AddYears(2).ToString())
        { 
        
        }
    }
}
