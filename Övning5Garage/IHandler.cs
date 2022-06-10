namespace Övning5Garage
{
    public interface IHandler
    {
        void Add(Vehicle item);
        void Remove(Vehicle item);
        List<Vehicle> GetAllVehicles();
    }
}