using System;

namespace ConsoleApp1
{
    class Person
    {
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Person p1 = new Person() { Name = "John Doe" };
            Person p2 = new Person() { Name = "John Doe" };
            if (p1 == p2)
            {
                Console.WriteLine("p1==p2 is true");
            } else
            {
                Console.WriteLine("p1==p2 is false");
            }
            if (p1.Equals(p2))
            {
                Console.WriteLine("p1.Equals(p2) is true");
            } else
            {
                Console.WriteLine("p1.Equals(p2) is false");
            }
        }
    }
}
