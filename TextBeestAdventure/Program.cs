using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static TextBeestAdventure.Command;

namespace TextBeestAdventure
{



    internal class Program
    {
        static void Main(string[] args)
        {
            Command walk = new Command("Walk", "Walk to another available room", Walk, Commands.Walk);
            Command jump = new Command("Jump", "Jump to another available room", Jump, Commands.Jump);

            Console.WriteLine($"type{walk.Accessor} of type {(int)walk.Accessor}om naar een kamer te lopen");
            string choise = Console.ReadLine();



            if (int.TryParse(choise, out int test))
            {
                if (test == (int)walk.Accessor)
                {
                    Console.WriteLine("ik loop doormiddel van een nummer");
                }

                else if (test == (int)jump.Accessor)
                {
                }

                if (choise.ToLower() == "walk")
                {
                    Console.WriteLine("We gaan lopen");
                }

                if (choise.ToLower() == "jump")
                {
                    Console.WriteLine("We gaan springen");
                }


            }
        }

        public static void test() { }
        public static void Walk() { }
        public static void Jump() { }

    }

}
