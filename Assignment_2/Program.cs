// See https://aka.ms/new-console-template for more information

using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Text;
using System.Text.RegularExpressions;

//1
int[] nums = [1, 2, 3, 4, 5, 6, 7, 124, 621, -1];
int[] numCopy = new int[nums.Length];
for (int i = 0; i < nums.Length; i++)
{
    numCopy[i] = nums[i];
}
Console.WriteLine("[{0}]", string.Join(", ", nums));
Console.WriteLine("[{0}]", string.Join(", ", numCopy));


//2

List<string> ToDoList = new List<string>();
for (; true;)
{
    Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
    string currentChar = Console.ReadLine();
    if (currentChar == "--")
    {
        ToDoList.Clear();
    }
    else if (currentChar != null && currentChar[0] == '+')
    {
        ToDoList.Add(currentChar.Substring(1));
    }
    else if (currentChar != null && currentChar[0] == '-')
    {
        ToDoList.Remove(currentChar.Substring(1));
    }
    else
    {
        Console.WriteLine("Command entered is not valid.");
    }
    Console.WriteLine("[{0}]", string.Join(", ", ToDoList));
}


//3

static int[] FindPrimesInRange(int startNum, int endNum)
{
    List<int> res = new List<int>();
    for (int i = startNum; i <= endNum; i++)
    {
        bool isPrime = true;
        for (int j = 2; j <= i / 2; j++)
        {
            if (i % j == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime)
        {
            res.Add(i);
        }
    }
    return res.ToArray();
}

Console.WriteLine("Please enter the first number: ");
int start = int.Parse(Console.ReadLine());
Console.WriteLine("Please enter the second number: ");
int end = int.Parse(Console.ReadLine());
if (start > end)
{
    Console.WriteLine("The end number should be greater than the start number.");
}
else
{
    int[] output = FindPrimesInRange(start, end);
    Console.WriteLine("[{0}]", string.Join(", ", output));
}


//4

Console.WriteLine("Please enter your array of integers, separated by spaces.");
var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
Console.WriteLine("Please enter the number of rotations.");
int rot = int.Parse(Console.ReadLine());
int[] res = new int[array.Length];
int l = array.Length;
for (int i = 0; i < array.Length; i++)
{
    for (int j = 1; j <= rot; j++)
    {
        res[i] = res[i] + array[((i - j) % l + l) % l];
    }
}
Console.WriteLine("[{0}]", string.Join(", ", res));


//5


Console.WriteLine("Please enter your array of integers, separated by spaces.");
var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
int len = arr.Length;
int cnt = 1; int now = arr[0];
int max = 1;
for (int i = 1; i < len; i++)
{
    if (array[i] == arr[i - 1])
    {
        cnt++;
        if (i == len - 1)
        {
            if (cnt > max)
            {
                max = cnt;
                now = arr[i - 1];
            }
        }
    }
    else
    {
        if (cnt > max)
        {
            max = cnt;
            now = arr[i - 1];
            cnt = 0;
        }
    }
}
int[] result = new int[max];
for (int i = 0; i < max; i++)
{
    result[i] = now;
}
Console.WriteLine("The result is:");
Console.WriteLine("[{0}]", string.Join(", ", result));



//6

Console.WriteLine("Please enter your array of integers, separated by spaces.");
var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
Dictionary<int, int> numCount = new Dictionary<int, int>();
foreach (int item in array)
{
    if (numCount.ContainsKey(item))
    {
        numCount[item]++;
    }
    else
    {
        numCount[item] = 1;
    }
}
int current = 0; int max = 0;
for (int i = 0; i < array.Length; i++)
{
    if (max < numCount[array[i]])
    {
        current = array[i];
        max = numCount[array[i]];
    }
}
Console.WriteLine($"The most frequent integer is {current}, it appears {max} times.");


//1(a)

Console.WriteLine("Please enter your string.");
char[] array = Console.ReadLine().ToCharArray();
Array.Reverse(array);
Console.WriteLine(new string(array));


//1(b)

Console.WriteLine("Please enter your string.");
string input = Console.ReadLine();
string res = "";
for (int i = input.Length - 1; i >= 0; i--)
{
    res += input[i];
}
Console.WriteLine(res);


//2

string pattern = @"([.,:;=\(\)&\[\]\""\'\\\/!? ]+)";
Console.WriteLine("Please enter your sentence: ");
string input = Console.ReadLine();
string[] parts = Regex.Split(input, pattern);
List<string> words = new List<string>();

//Console.WriteLine("[{0}]", string.Join(", ", parts));
foreach (string part in parts)
{
    if (!Regex.IsMatch(part, pattern) & !string.IsNullOrEmpty(part))
    {
        words.Add(part);
    }
}
words.Reverse();
int pos = 0;
for (int i = 0; i < parts.Length; i++)
{
    if (!Regex.IsMatch(parts[i], pattern) && !string.IsNullOrEmpty(parts[i]))
    {
        parts[i] = words[pos];
        pos++;
    }
}
Console.WriteLine("[{0}]", string.Join("", parts));


//3

string pattern = @"([a-z]+)";
Console.WriteLine("Please enter your sentence: ");
string[] parts = Regex.Split(Console.ReadLine(), pattern, RegexOptions.IgnoreCase);
List<string> words = new List<string>();
foreach (string part in parts)
{
    if (Regex.IsMatch(part, pattern, RegexOptions.IgnoreCase) && !string.IsNullOrEmpty(part))
    {
        words.Add(part);
    }
}
words.Distinct().ToList();
List<string> result = new List<string>();
foreach (string word in words)
{
    bool isPalin = true;
    int l = word.Length;
    for (int i = 0; i <= l / 2; i++)
    {
        if (word[i] != word[l - i - 1])
        {
            isPalin = false;
            break;
        }
    }
    if (isPalin)
    {
        result.Add(word);
    }
}
Console.WriteLine("[{0}]", string.Join(", ", result));


//4
Console.WriteLine("Please enter your url: ");
string url = Console.ReadLine();
string protocal = ""; string server = ""; string resource = "";
int position = url.IndexOf("://");
if(position != -1)
{
    protocal = url.Substring(0, position);
    url = url.Substring(position + 3);
}
position = url.IndexOf("/");
if(position != -1)
{
    server = url.Substring(0, position);
    resource = url.Substring(position + 1);
}
else
{
    server = url;
}
Console.WriteLine($"[protocal] = \"{protocal}\"");
Console.WriteLine($"[server] = \"{server}\"");
Console.WriteLine($"[resource] = \"{resource}\"");
