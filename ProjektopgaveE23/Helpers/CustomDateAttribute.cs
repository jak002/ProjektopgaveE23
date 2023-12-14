using System.ComponentModel.DataAnnotations;

namespace ProjektopgaveE23.Helpers
{
    public class CustomDateAttribute : RangeAttribute
    {

        public CustomDateAttribute()
            :base (typeof(DateTime),
                 DateTime.Now.ToString(),
                 DateTime.Now.AddYears(2).ToString())
        {
            
        }
    }
}
