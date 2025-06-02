using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static TextBeestAdventure.Command;

namespace TextBeestAdventure
{



    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(Commands.walk);

            List<Commands> commands = new List<Commands>()
            {
                Commands.walk,
                Commands.jump,
                Commands.fly,
                Commands.run
            };

            List<Commands> commandsv2 = Enum.GetValues(typeof(Commands)).Cast<Commands>().ToList();

            Console.WriteLine("Maak een keuze");

            foreach (Commands command in commandsv2) 
            { 
                Console.WriteLine(command); 
            }

            string input = Console.ReadLine();
            Commands currentCommand = Commands.Error;

            for (int i = 0; i < commands.Count; i++)
            {
                if (input == commands[i].ToString())
                {
                    currentCommand;
                }
            }


            switch (input) 
            {
                case Commands.Walk:
                    break;

                default:
                    break;
            }


            //Command walk = new Command("Walk", "Walk to another available room", Walk, Commands.Walk);
            //Command jump = new Command("Jump", "Jump to another available room", Jump, Commands.Jump);

            //Console.WriteLine($"type{walk.Accessor} of type {(int)walk.Accessor}om naar een kamer te lopen");
            //string choise = Console.ReadLine();



            //if (int.TryParse(choise, out int test))
            //{
            //    if (test == (int)walk.Accessor)
            //    {
            //        Console.WriteLine("ik loop doormiddel van een nummer");
            //    }

            //    else if (test == (int)jump.Accessor)
            //    {
            //    }

            //    if (choise.ToLower() == "walk")
            //    {
            //        Console.WriteLine("We gaan lopen");
            //    }

            //    if (choise.ToLower() == "jump")
            //    {
            //        Console.WriteLine("We gaan springen");
            //    }


            //}
        }

        public enum Commands
        {
            walk,
            jump,
            fly,
            run
        }


        //public static void test() { }
        //public static void Walk() { }
        //public static void Jump() { }

    }

}
