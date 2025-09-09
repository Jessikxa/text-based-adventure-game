using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBeestAdventure
{
    internal class Kitchen : Room
    {

        public string InteractionText;
        public Kitchen(string roomName, string roomDescription) : base(roomName, roomDescription)
        {
            string roomname = roomName;
            string roomdescription = roomDescription;
        }

        public override void RoomFunctions()
        {
            Console.WriteLine("je bent in de keuken wat wil je doen?");

            Console.WriteLine("At first you only see the room but after a minute or so of looking around you hear a voice and turn around frightened." +

            "'WHAT DO YOU THINK YOU'RE DOING HERE?'" + "A soul, shaking in anger, which a cleaver in hand"); 

            Kitchen kitchen = new Kitchen("kitchen", InteractionText);
            Console.WriteLine(kitchen.InteractionText);

            Console.WriteLine("What do you answer:");

            Console.WriteLine("a - \"Looking around for something\"");
            Console.WriteLine("b - \"None of your business\"");

            string Choice = Console.ReadLine();

            if (Choice == "a")
            {
                Console.WriteLine("Ahh i can see you're cursed. I know what you are looking for. Here's an goats eye item.");
                //{ you be questioned further but will most likely will get an item
            }
            if (Choice == "b")
            {
                Console.WriteLine();
                //    you will be met with more anger and given nothing. every time you try to enter the room you will be denied}
                Console.WriteLine("The soul becomes even more angry and makes you leave.");
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }
    }
}
