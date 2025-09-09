using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextBeestAdventure
{
    internal class Dining_Room : Room 
    {
       
        bool searching;

        public Dining_Room(string roomName, string roomDescription) : base(roomName, roomDescription)
        {
        }

        //Console.WriteLine(dining.InteractionText);

           public override void RoomFunctions(InventorySystem inventory)
        {
            bool itemGiven = false;
            bool makingChoice = true;

            Console.WriteLine("You see a soul sitting on one of the chairs at the dining table, twirling her hair whilst looking \r\nuninterested and kicking her feet. Another wearing a long, fluffly see through boa, using a knife \r\nand fork, cutting into an empty plate. A few others standing around looking at the artwork, or \r\npicking up items on the drawers.\r\n\r\nThey don't seem to care that you have entered into their space. Not giving you the time of day, \r\nyou decide to keep walking further into the room and ask the little boy, who you presume is sitting \\r\\nnext to their mother and the only person who looked up, if he new anything.\\r\\n");
            Console.WriteLine("a - \"Hello there, im not feeling so well. can you maybe help me?\"");

            Console.WriteLine("b - \"I need answers now!\"");

            
            Item fur = Items.FirstOrDefault(i => i.Name == "fur");

            while (makingChoice)
            {
                string choice = Console.ReadLine().ToLower();
                if (choice == "a")
                {
                    Console.WriteLine("The boy empathises.");


                    if (fur != null)
                    {
                        inventory.AddItem(fur);
                        Items.Remove(fur);
                        Console.WriteLine("You picked up the teddy's fur.\n");
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
                    Console.WriteLine("You frighten the boy and he runs off with the item.\n");
                    if (fur != null)
                    {
                        Items.Remove(fur); // Remove the item so cant be picked up later
                    }
                    makingChoice = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. try again");
                }
            }
            
        }
    }
}
