using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Interfaces
{
    public interface IEventRepository
    {
        void AddEvent(Event ev);

        List<Event> GetAllEvents();

        Event GetEvent(int id);

        void UpdateEvent (Event updatedEvent);

        void DeleteEvent(Event eventToDelete);

    }
}
