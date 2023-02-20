using System;

namespace LinkedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList links = new LinkedList();
            links.Append(10);
            links.Prepend(24);
            links.Traverse();
            links.Reverse();
            links.Traverse();
            links.SetValue(1887, 1);
            links.RemoveByIndex(0);
            links.Traverse();
            Console.WriteLine(links.GetValue(5));
            Console.WriteLine("Length: " + links.Legnth);
        }
    }
}
