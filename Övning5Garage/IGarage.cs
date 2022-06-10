
namespace Övning5Garage
{
    public interface IGarage<T> : IEnumerable<T> where T : Vehicle
    {
        T this[int index] { get; }

        bool IsEmpty { get; }
        bool IsFull { get; }
        int Length { get; }

        bool Add(T item);
        IEnumerator<T> GetEnumerator();
        bool Remove(T item);
    }
}