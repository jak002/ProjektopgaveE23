using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Interfaces
{
    public interface IBoatRepository
    {
        List<Boat> GetAllBoats();
        Boat GetBoat(int id);

        void AddBoat(Boat bo);

        void UpdateBoat(Boat bo);
        void DeleteBoat(Boat boatToUpdate);
        List<Boat> FilterBoats(string filterCriteria);
        List<Boat> SearchBoatByModel(string model);
    }
}
