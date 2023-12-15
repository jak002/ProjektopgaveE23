using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Interfaces
{
    public interface IEventRepository
    {
        /// <summary>
        /// Adds event to Json file.
        /// Generates a unique ID for the event
        /// </summary>
        /// <param name="ev"></param>
        void AddEvent(Event ev);

        List<Event> GetAllEvents();

        Event GetEvent(int id);

        void UpdateEvent (Event updatedEvent);

        void DeleteEvent(Event eventToDelete);

    }
}
