// See https://aka.ms/new-console-template for more information

using Assignment_4;

MyStack<int> stack = new MyStack<int>();

for (int i = 0; i < 10; i++)
{
    stack.Push(i);
    if (i % 2 == 0)
    {
        stack.Pop();
    }
}

stack.GetAll();