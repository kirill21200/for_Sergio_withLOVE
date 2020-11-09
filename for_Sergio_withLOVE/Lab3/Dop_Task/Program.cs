using Lab3;
using System;
using System.Linq;

namespace Dop_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new AeroDataContext();
            var query = from info in db.Audio select info;
            foreach (var i in query)
            {
                Console.WriteLine($"{i.Id} {i.Singer} {i.Title} {i.Year} {i.Album} {i.Comment}");
            }
            Console.WriteLine("Ok");
            Console.ReadKey();
        }
    }
}
