using DiamondMakerApp.Model;
using System;
using System.Linq;

namespace DiamondMakerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!args.Any())
            {
                Console.WriteLine($"Enter valid character from the alphabet");
                return;
            }   

            var diamond = new Diamond();
            diamond.Create(args[0]);
            foreach (var line in diamond.Rows())
            {
                Console.WriteLine(line);
            }
        }
    }
}
