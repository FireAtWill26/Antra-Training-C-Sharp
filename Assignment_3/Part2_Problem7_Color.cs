using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class Color
    {
        int red
        {
            get { return red; }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new Exception("The value should in between 0 and 255");
                }
            }
        }
        int green
        {
            get { return green; }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new Exception("The value should in between 0 and 255");
                }
            }
        }
        int blue
        {
            get { return blue; }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new Exception("The value should in between 0 and 255");
                }
            }
        }
        int alpha
        {
            get { return alpha; }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new Exception("The value should in between 0 and 255");
                }
            }
        }
        public Color(int Red, int Green, int Blue, int Alpha = 255)
        {
            if (Red > 255) { red = 255; }
            else if (Red < 0) { red = 0; }
            else { red = Red; }
            if (Green > 255) { green = 255; }
            else if (Green < 0) { green = 0; }
            else { green = Green; }
            if (Blue > 255) { blue = 255; }
            else if (Blue < 0) { blue = 0; }
            else { blue = Blue; }
            if (Alpha > 255) { alpha = 255; }
            else if (Alpha < 0) { alpha = 0; }
            else { alpha = Alpha; }
        }
        public float GetGrayScale()
        {
            return ((float)red + (float)green + (float)blue) / 3;
        }
    }
}