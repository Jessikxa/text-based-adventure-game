using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        
        public override void RoomFunctions(InventorySystem inventory)
        {
            bool itemGiven = false;
            bool makingChoice = true;

            Console.WriteLine("At first you only see the room but after a minute or so of looking around you hear a voice and turn around frightened." +
                "'WHAT DO YOU THINK YOU'RE DOING HERE?' A soul, shaking in anger, with a cleaver in hand");

            Console.WriteLine("What do you answer:");
            Console.WriteLine("a - \"Looking around for something\"");
            Console.WriteLine("b - \"None of your business\"");

            
            Item goatsEye = Items.FirstOrDefault(i => i.Name == "Goats Eye");

            while (makingChoice)
            {
                string choice = Console.ReadLine();
                if (choice == "a")
                {
                    Console.WriteLine("Ahh, I can see you're cursed. I know what you are looking for.");
                    //Item goatsEye = Items.FirstOrDefault(i => i.Name == "Goats Eye");
                    if (goatsEye != null)
                    {
                        inventory.AddItem(goatsEye);
                        Items.Remove(goatsEye);
                        Console.WriteLine("You picked up the Goat's Eye.\n");
                        itemGiven = true;
                    }
                    else
                    {
                        Console.WriteLine("There is nothing left to give you.");
                    }
                    makingChoice = false;
                }
                else if (choice == "b")
                {
                    Console.WriteLine("The soul becomes even more angry and makes you leave.\n");
                    if (goatsEye != null)
                    {
                        Items.Remove(goatsEye); // Remove the item so cant be picked up later
                    }
                    makingChoice = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            
        }
    }
}
