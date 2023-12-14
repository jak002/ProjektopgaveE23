using ProjektopgaveE23.Helpers;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Services
{
    public class EventRepository : IEventRepository
    {
        
        private string filepath = @"Data/jsonEvents.json";

        /// <summary>
        /// Adds event to Json file.
        /// Generates a unique ID for the event
        /// </summary>
        /// <param name="ev">New Event object</param>
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

        /// <summary>
        /// Deletes an event from Json file based on an event object.
        /// </summary>
        /// <param name="eventToDelete">Event object you wish to delete</param>
        public void DeleteEvent(Event eventToDelete)
        {
            List<Event> events = GetAllEvents();
            events.Remove(eventToDelete);
            JsonFileWriter<Event>.WriteToJson(events, filepath);
        }

        /// <summary>
        /// returns a list with all events. read from Json file
        /// </summary>
        /// <returns>List of all events</returns>
        public List<Event> GetAllEvents()
        {

            return JsonFileReader<Event>.ReadJson(filepath);

        }

        /// <summary>
        /// This method returns an event object based on the given event ID
        /// </summary>
        /// <param name="id">ID of the event you wish to find</param>
        /// <returns>Event object</returns>
        public Event GetEvent(int id)
        {
            foreach (var events in GetAllEvents())
            {
                if (events.Id == id)
                    return events;
            }
            return new Event();
        }

        /// <summary>
        /// This method updates an already existing event. It finds the matching ID
        /// and replaces the old info with the new updated info.
        /// It also updates the Json file.
        /// </summary>
        /// <param name="updatedEvent">The updated Event object</param>
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
