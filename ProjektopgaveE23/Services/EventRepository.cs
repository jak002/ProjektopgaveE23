using ProjektopgaveE23.Helpers;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Services
{
    public class EventRepository : IEventRepository
    {
        
        private string filepath = @"Data/jsonEventss.json";

        public void AddEvent(Event ev)
        {
            List<int> eventIds = new List<int>();
            List<Event> events = GetAllEvents();

            foreach (var evt in events)
            {
                eventIds.Add(evt.Id);
            }
            if (eventIds.Count != 0)
            {
                int start = eventIds.Max();
                ev.Id = start + 1;
            }
            else
            {
                ev.Id = 1;
            }
            events.Add(ev);
            JsonFileWriter<Event>.WriteToJson(events, filepath);
        }

        public void DeleteEvent(Event eventToDelete)
        {
            List<Event> events = GetAllEvents();
            events.Remove(eventToDelete);
            JsonFileWriter<Event>.WriteToJson(events, filepath);
        }

        public List<Event> GetAllEvents()
        {

            return JsonFileReader<Event>.ReadJson(filepath);

        }

        public Event GetEvent(int id)
        {
            foreach (var events in GetAllEvents())
            {
                if (events.Id == id)
                    return events;
            }
            return new Event();
        }

        public void UpdateEvent(Event updatedEvent)
        {
            if (updatedEvent != null)
            {
                List<Event> events = GetAllEvents();
                foreach (Event evt in events)
                {
                    if (updatedEvent.Id == evt.Id)
                    {
                        evt.Id = updatedEvent.Id;
                        evt.Name = updatedEvent.Name;
                        evt.Date = updatedEvent.Date;
                        evt.Place = updatedEvent.Place;
                        evt.Attendees = updatedEvent.Attendees; //måske væk
                        evt.Description = updatedEvent.Description;
                        //måske image også 
                        break;
                    }

                }
                JsonFileWriter<Event>.WriteToJson(events, filepath);
            }
        }
    }
}
