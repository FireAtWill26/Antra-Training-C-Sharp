// See https://aka.ms/new-console-template for more information
using System.Text;

//Problem number is commented before the each blocks of the code.

//Part 1, Problem 1.
using Assignment_1;

TypeInformation demo = new TypeInformation();
string[] arr = ["sbyte", "byte", "short", "ushort", "int", "uint", "long", "ulong", "float", "double", "decimal"];
Dictionary<string, Type> typeDic = new Dictionary<string, Type>()
{
    {"sbyte", typeof(sbyte)},
    {"byte", typeof(byte)},
    {"short", typeof(short)},
    {"ushort", typeof(ushort)},
    {"int", typeof(int)},
    {"uint", typeof(uint)},
    {"long", typeof(long)},
    {"ulong", typeof(ulong)},
    {"float", typeof(float)},
    {"double", typeof(double)},
    {"decimal", typeof(decimal)},
};
for (int i = 0; i < arr.Length; i++)
{
    if (typeDic.TryGetValue(arr[i], out Type type))
    {
        demo.ReturnInfo(type);
    }
    else
    {
        Console.WriteLine($"{arr[i]} is not a valid type.");
    }
}



//Part 1, Problem 2.
Console.WriteLine("Please enter the number of centuries: ");
byte century = byte.Parse(Console.ReadLine());
uint years = (uint)100 * century;
uint days = (uint)36524 * century;
uint hours = 24 * days;
ulong minutes = 60 * hours;
ulong seconds = 60 * minutes;
ulong milliseconds = 1000 * seconds;
ulong microseconds = 1000 * milliseconds;
ulong nanoseconds = 1000 * microseconds;
Console.WriteLine($"{century} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds " +
    $"= {microseconds} microseconds = {nanoseconds} nanoseconds.");


//Part 2, Problem 1.
string res = "1";
for (int i = 2; i <= 100; i++)
{
    if(i % 3 == 0)
    {
        if(i % 5 == 0)
        {
            res += ", fizzbuzz";
            continue;
        }
        else
        {
            res += ", fizz";
        }
    }
    else if(i % 5 == 0)
    {
        res += ", buzz";
    }
    else
    {
        res += $", {i}";
    }
}
Console.WriteLine(res);

//For the executing given code part, we will get an infinite loop after execution since byte type will never get to 500 and when it overflow, it will get the corresponding 
//value in the range of byte by modular arithmetic. We can add an if statement to the code so it becomes 
int max = 500;
for (byte i = 0; i < max; i++)
{
    Console.WriteLine(i);
    if (i == byte.MaxValue)
    {
        Console.WriteLine("Warning: i has reached the maximal value for byte type and start to overflow.");
        break;
    }
}
//The for loop will now break when i reach the maximal value for byte and prevent infinite loop from happening.


//Part 2, Problem 2.
Console.WriteLine("Please enter the number of levels you want: ");
int level = int.Parse(Console.ReadLine());
for (int i = 1; i <= level; i++)
{
    string floor = "";
    for (int j = 0; j < level - i; j++)
    {
        floor += " ";
    }
    for (int k = 0; k < 2 * i - 1; k++)
    {
        floor += "*";
    }
    Console.WriteLine(floor);
}



//Part 2, Problem 3.
int correctNumber = new Random().Next(3) + 1;
int guessedNumber = -1;
for (; true;)
{
    Console.WriteLine("Please enter your next guess: ");
    guessedNumber = int.Parse(Console.ReadLine());
    if (guessedNumber == correctNumber)
    {
        Console.WriteLine("Congratulation, your guess is correct!");
        break;
    }
    if (guessedNumber < 1 || guessedNumber > 3)
    {
        Console.WriteLine("Your guess is out of range, please enter a number greater or equal to 1 and less or equal to 3.");
    }
    else if (guessedNumber < correctNumber)
    {
        Console.WriteLine("Your guess is low.");
    }
    else
    {
        Console.WriteLine("Your guess is high.");
    }
}




//Part 2, Problem 4.
Console.WriteLine("Please enter your birth date in the format (yyyy-mm-dd):");
string input = Console.ReadLine();
DateTime birthDate;
if (DateTime.TryParse(input, out birthDate))
{
    DateTime currentDate = DateTime.Now;
    TimeSpan dayAge = currentDate - birthDate;
    int dayCount = dayAge.Days;
    Console.WriteLine($"You are currently {(int)(dayCount)} days old.");
    int daysToNextAnniversary = 10000 - (dayCount % 10000);
    Console.WriteLine($"Your next anniversary is {currentDate.AddDays(daysToNextAnniversary).ToString("yyyy-mm-dd")}.");
}
else
{
    Console.WriteLine("Birth date not in valid format.");
}




//Part 2, Problem 5.
DateTime time = DateTime.Now;
Console.WriteLine($"The time is {time}.");
if (time.Hour < 12 && time.Hour >= 6)
{
    Console.WriteLine("Good Morning");
}
if (time.Hour >= 12 && time.Hour < 17)
{
    Console.WriteLine("Good Afternoon");
}
if (time.Hour >= 17 && time.Hour < 21)
{
    Console.WriteLine("Good Evening");
}
if (time.Hour >= 21 || time.Hour < 6)
{
    Console.WriteLine("Good Night");
}




//Part 2, Problem 6.
for (int i = 1; i < 5; i++)
{
    string result = "0";
    for (int j = i; j < 25; j = j + i)
    {
        result += $", {j}";
    }
    Console.WriteLine(result);
}
