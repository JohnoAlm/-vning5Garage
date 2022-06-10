using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5Garage
{
    public class Garage<T> : IGarage<T> where T : Vehicle
    {
        // Privata fält

        // Kapaciteten för arrayen
        private int _capacity;

        // Den interna arrayen
        private T[] _array;

        // Publika properties

        // Antal element i arrayen
        public int Length
        {
            get { return _array.Length; }
        }

        // Kollar om arrayen är full
        public bool IsFull
        {
            get
            {
                return _capacity < Length;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return _array.Length == 0;
            }
        }

        public T this[int index] => _array[index];

        // Garage konstruktorn tar kapaciteten för arrayen
        public Garage(int capacity)
        {
            _capacity = Math.Max(capacity, 2);
            _array = new T[_capacity];
        }

        // Add(T item) metod som tar in T item och sätter värdet genom _array.SetValue(item, i);
        public bool Add(T item)
        {
            ArgumentNullException.ThrowIfNull(item, "item");

            if (IsFull)
            {
                return false;
            }

            for (int i = 0; i < Length; i++)
            {
                // Gör en null check på indexen att den är null för att inte skriva över positionen
                if (_array[i] == null)
                {
                    _array.SetValue(item, i);
                    break;
                }


            }
            return true;
        }

        // Remove(T item) metod som tar Array.IndexOf(_array, item) för att hitta indexen av objektet eller fordonet och sätter sedan den indexen till null
        public bool Remove(T item)
        {
            ArgumentNullException.ThrowIfNull(item, "item");

            if (IsEmpty)
            {
                return false;
            }

            var itemIndex = Array.IndexOf(_array, item);

            _array[itemIndex] = null;

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _array)
            {
                //....
                if (item != null)
                    yield return item;
            }

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
