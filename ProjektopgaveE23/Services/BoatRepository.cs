using ProjektopgaveE23.Helpers;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Services
{
    public class BoatRepository : IBoatRepository
    {
        private string jsonFileName = @"Data\JsonBoats.json";
        public void AddBoat(Boat bo)
        {
            List<int> boatIds = new List<int>();
            List<Boat> boats = GetAllBoats();
            foreach (var boat in boats)
            {
                boatIds.Add(boat.Id);
            }
            if (boatIds.Count != 0)
            {
                int start = boatIds.Max();
                bo.Id = start + 1;
            }
            else
            {
                bo.Id = 1;
            }
            boats.Add(bo);
            JsonFileWriter<Boat>.WriteToJson(boats, jsonFileName);
        }

        public void DeleteBoat(Boat boatToUpdate)
        {
            List<Boat> boats = GetAllBoats();
            boats.Remove(boatToUpdate);
            JsonFileWriter<Boat>.WriteToJson(boats, jsonFileName);
        }

        

        public List<Boat> GetAllBoats()
        {
            return JsonFileReader<Boat>.ReadJson(jsonFileName);
        }

        public Boat GetBoat(int id)
        {
            foreach (Boat boat in GetAllBoats())
            {
                if (boat.Id == id)
                    return boat;
            }
            return new Boat();
        }

        public void UpdateBoat(Boat bo)
        {
            if (bo != null)
            {
                List<Boat> boats = GetAllBoats();
                foreach (Boat b in boats)
                {
                    if (bo.Id == b.Id)
                    {
                        b.Id = bo.Id;
                        b.Name = bo.Name;
                        b.Description = bo.Description;
                        b.BoatModel = bo.BoatModel;
                        break;
                    }
                }
                JsonFileWriter<Boat>.WriteToJson(boats, jsonFileName);
            }
        }
    }
}
