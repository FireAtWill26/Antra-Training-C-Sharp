using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02UnderstandingTypes;

public class TypeInformation
{
    public void ReturnInfo(Type type)
    {
        Console.WriteLine($"{type} uses {System.Runtime.InteropServices.Marshal.SizeOf(type)} bytes memory,");
        Console.WriteLine($"The minimum value is {type.GetField("MinValue").GetValue(null)},");
        Console.WriteLine($"The maximum value is {type.GetField("MaxValue").GetValue(null)}.");
        Console.WriteLine("===========");
    }
}
