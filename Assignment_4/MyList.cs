using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class MyList<T>
    {
        Dictionary<int, T> _list = new Dictionary<int, T>();

        int idx;

        public MyList()
        {
            idx = 0;
        }
        public void Add(T item)
        {
            _list[idx] = item;
            idx++;
        }
        public T Remove(int index)
        {
            return _list[index];
            _list.Remove(index);
        }
        public bool Contain(T element)
        {
            if (_list.Values.Contains(element))
            {
                return true;
            }
            return false;
        }
        public void Clear()
        {
            _list.Clear();
        }
        public void InsertAt(T item, int index)
        {
            if(index < idx)
            {
                _list[index] = item;
            }
            Console.WriteLine($"Please enter an index less or equal to {idx - 1}");
        }
        public void DeleteAt(int index)
        {
            _list.Remove(index);
        }
        public T Find(int index)
        {
            return _list[index];
        }
    }
}
