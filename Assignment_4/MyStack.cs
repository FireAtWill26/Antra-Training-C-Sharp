using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class MyStack<T>
    {
        List<T> stack = new List<T>();

        public int Count()
        {
            return stack.Count;
        }

        public T Pop()
        {
            T res = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return res;
        }
        public void Push(T item)
        {
            stack.Add(item);
        }
        public void GetAll()
        {
            Console.WriteLine("[{0}]", string.Join(", ", stack));
        }
    }
}
