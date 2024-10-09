// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball
{
    
    public class Ball
    {
        public static void Main(string[] args)
        {
            Color color1 = new Color(24, 124, 52);
            Color color2 = new Color(43, 152, 231);
            Ball ball1 = new Ball(4, color1);
            Ball ball2 = new Ball(2, color2);
            for (int i = 1; i <= 10; i++)
            {
                ball1.Throw();
                if (i % 2 == 0) { ball2.Throw(); }
                if (i % 9 == 0) { ball1.Pop(); }
                if (i % 5 == 0) { ball2.Pop(); }
            }
            Console.WriteLine($"The first ball is thrown {ball1.timeThrown} times and the second ball is thrown {ball2.timeThrown} times");
        }
        float size;
        Color color { get; set; }
        int timeThrown;

        public Ball(float size, Color color)
        {
            this.size = size;
            this.color = color;
        }
        public void Pop()
        {
            size = 0;
        }
        public void Throw()
        {
            if (size == 0) { return; }
            else { timeThrown++; }
        }
        public int GetTime() { return timeThrown; }
    }
}
