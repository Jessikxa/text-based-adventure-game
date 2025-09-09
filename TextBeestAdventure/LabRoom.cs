using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TextBeestAdventure
{
    internal class LabRoom : Room
    {
        bool makingChoice;
        public LabRoom(string roomName, string roomDescription) : base(roomName, roomDescription)
        {

        }

        public override void RoomFunctions(InventorySystem inventory)
        {



            base.RoomFunctions(inventory);
            bool itemGiven = false;
            bool makingChoice = true;

            Console.WriteLine("\"As soon as you enter you see a few souls hanging around a desk, looking at notes on the desk, chatting with each other about a certain formulas . A few more discussing and writing stuff on the chalkboard. all noice in the room stops and they stare at the door.\n 'who are you?' one says. 'what are you doing here?' another says, louder.");

            Console.WriteLine(" a - \"who are you?!\"");
            Console.WriteLine(" b - \"my name is {wizardName} and i'm cursed you see. i have come to find a cure. Can you help me?\"");

            //string choice = Console.ReadLine().ToLower();
            Item flask = Items.FirstOrDefault(i => i.Name == "flask");

            while (makingChoice)
            {
                string choice = Console.ReadLine().ToLower();
                if (choice == "a")
                {
                    Console.WriteLine("The ghost frowns and hides something behind his back.");
                    if (flask != null)
                    {
                        // Remove the item so it can't be picked up later
                        Items.Remove(flask);
                    }
                    makingChoice = false;
                }
                else if (choice == "b")
                {
                    Console.WriteLine("The souls are willing to help and give you an item. They give you a flask with pink liquid.");

                    if (flask != null)
                    {
                        inventory.AddItem(flask);
                        Items.Remove(flask);
                        Console.WriteLine("You picked up the flask.\n");
                        itemGiven = true;
                    }
                    makingChoice = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.\n");
                }
            }

            //if(choice == "a")
            //{
            //    Console.WriteLine("You are met with hostility and will not receive an item.");
            //}
            //else if(choice == "b")
            //{
            //    Console.WriteLine("The souls are be more willing to help and give you an item. They give you a flask with pink liquid.");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid input. Try again.");
            //}
            //{ You will be met with hostility and not given an item.or a bad item(maybe implement later in game)}

            //if (b)
            //{ The souls will be more willing to help and give you an item}

            //NPC lab = new NPC(InteractionText);
            //Console.WriteLine(lab.InteractionText);
        }

    }
}
