using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public static class Problem_1
    {
        public static void Main(string[] args)
        {
            int[] numbers = GenerateNumbers();
            Reverse(numbers);
            PrintNumbers(numbers);
        }

        public static int[] GenerateNumbers(int length = 10)
        {
            int[] res = new int[length];
            for (int i = 0; i < length; i++)
            {
                res[i] = i + 1;
            }
            return res;
        }

        public static int[] Reverse(int[] input)
        {
            int temp = 0;
            for (int i = 0; i < input.Length / 2; i++)
            {
                temp = input[i];
                input[i] = input[input.Length - 1 - i];
                input[input.Length - 1 - i] = temp;
            }
            return input;
        }

        public static void PrintNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }

    public static class Problem_2
    {

        public static void Main(string[] args)
        {
            int[] sequence = Fibonacci();
            for (int i = 0; i < sequence.Length || i < 10; i++)
            {
                Console.WriteLine(sequence[i]);
            }

        }
        public static int[] Fibonacci(int num = 10)
        {
            int[] numbers = new int[num];
            if (num == 1)
            {
                numbers[0] = 1;
                return numbers;
            }
            else if (num == 2)
            {
                numbers[0] = 1;
                numbers[1] = 1;
                return numbers;
            }
            else
            {
                numbers[0] = 1;
                numbers[1] = 1;
                for (int i = 2; i < num; i++)
                {
                    numbers[i] = numbers[i - 1] + numbers[i - 2];
                }
                return numbers;
            }
        }
    }


}
