using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace TextBeestAdventure
{
    internal class Program 
    {
        static void Main(string[] args)
        {


            List<Room> rooms = new List<Room>();


            Ascii art = new Ascii();
            NPC kitchenNpc = new NPC("wee");
            NPC labNpc = new NPC("wee");
            NPC diningNpc = new NPC("wee");
            Dialog meep = new Dialog();
            Kitchen kitchenRoom = new Kitchen("", "");
            Dining_Room diningRooms = new Dining_Room("wee", "woo");



            //rooms
            Room starterRoom = new Room("Castle Entrance", " You stand in front of Avidrian's doorway. \nWhen you look up the stone walls seem to touch the sky. \nYou use the door knocker to knock three times. \nWhen knocking the third time, the door opens.");

            //starterRoom.add("north", 1);
            rooms.Add(starterRoom);
            //rooms[0].RoomFunctions();

            //room2
            Room Kitchen = new Room("The Kitchen", "If you can call it that, has rotten food caked on the floor and all surfaces, with loads of cobwebs. The smell is putrid and you become a little bit queasy. knives and pots are rusted. The only thing remotely clean are big wooden bowls.");
            //Kitchen.roomChoiceExit("east", 2);
            rooms.Add(Kitchen);

            //room3
            Room Lab = new Room("The Laboratorium", "flasks on the tables, with different coloured liquids, filled to differen levels. Books and pages littering the room. Some had gotton on the floor but most of the mess was on the tables and desk.");
            //Lab.roomChoiceExit("north", 3);
            rooms.Add(Lab);

            //room4
            Room diningRoom = new Room("The Dining Room", "The room is dusty but no apparent mess.");
            //diningRoom.roomChoiceExit("west", 4);
            rooms.Add(diningRoom);

            Room library = new Room("The Library", "on the brink of death you muster your way to the newly opened room. You enter the ancient library. Dusty tomes and mysterious books line the shelves. This is your last chance to find a cure using your knowledge and the items you've collected.");


            Item potion = new Item("Potion", "A mysterious glowing potion.");
            Item book = new Item("Book", "An old dusty spellbook.");
            Item apple = new Item("Apple", "A fresh red apple.");


            Kitchen.Items.Add(potion);
            Lab.Items.Add(book);
            diningRoom.Items.Add(apple);


            InventorySystem inventory = new InventorySystem();
            Character wizard = new Character("You", 100);

            art.asciiArt();
            Console.ReadLine();
            meep.introduction();

            int currentRoomIndex = 0;
            int directionsTaken = 0;
            int currentDay = 0;
            const int maxDays = 4;
            bool playing = true;

            Console.WriteLine(starterRoom.RoomDescription);
            Console.WriteLine("a - Enter castle");
            string desicion = Console.ReadLine();
            if (desicion != "a")
            {
                Console.WriteLine($"error. {desicion} is invalid. type in 'a'.");
            }

            while (playing)
            {


                Console.WriteLine($"Rooms you can enter");
                Console.WriteLine("North - Lab room");
                Console.WriteLine("East - Kitchen");
                Console.WriteLine("West - dining room");
                Console.WriteLine("Type 'stats' to view your health and inventory.");
                Console.WriteLine("Type 'exit' to quit the game");

                string choice = Console.ReadLine().ToLower();

                if (choice == "stats")
                {
                    wizard.DisplayHealth();
                    inventory.ListItems();
                    continue;
                }

                if (choice == "exit")
                {
                    Console.WriteLine("Exiting the game. Goodbye!");
                    break;
                }

                bool validOption = false;

                if (choice == "north")
                {
                    currentRoomIndex = rooms.IndexOf(Lab);
                    Console.WriteLine($"Rooms you can enter");
                    Console.WriteLine($" You entered {Lab.RoomName}. \n{Lab.RoomDescription}");


                    Console.ReadLine();
                    labNpc.labNPC();
                    validOption = true;

                }
                else if (choice == "east")
                {
                    currentRoomIndex = rooms.IndexOf(Kitchen);
                    Console.WriteLine($" You entered {Kitchen.RoomName}. \n{Kitchen.RoomDescription}");
                    Console.ReadLine();
                    kitchenRoom.RoomFunctions();
                    validOption = true;
                }
                else if (choice == "west")
                {
                    currentRoomIndex = rooms.IndexOf(diningRoom);
                    Console.WriteLine($" You entered {diningRoom.RoomName}. \n{diningRoom.RoomDescription}");
                    //diningNpc.diningNPC();
                    diningRooms.RoomFunctions();
                    validOption = true;

                }
                else
                {
                    Console.WriteLine("invalid input. try again.");
                }

                Room currentroom = rooms[currentRoomIndex];

                if (currentroom.Items.Count > 0)
                {

                    Console.WriteLine("You see the following items:");
                    for (int i = 0; i < currentroom.Items.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {currentroom.Items[i].Name} - {currentroom.Items[i].Description}");
                    }
                    Console.WriteLine("Type the number of the item to pick it up, or press Enter to skip:");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int itemIndex) && itemIndex > 0 && itemIndex <= currentroom.Items.Count)
                    {
                        Item pickedItem = currentroom.Items[itemIndex - 1];
                        inventory.AddItem(pickedItem);
                        currentroom.Items.RemoveAt(itemIndex - 1);
                        Console.WriteLine($"You picked up the {pickedItem.Name}.\n");
                    }
                }

                if (validOption)
                {
                    directionsTaken++;
                    if (directionsTaken >= 1)
                    {
                        directionsTaken = 0;
                        currentDay++;
                        wizard.LoseHealth(25);
                        wizard.DisplayHealth();
                        if (currentDay >= maxDays || wizard.Health <= 0)
                        {
                            playing = false;
                            //Console.WriteLine("You are sick and too tired so you fall asleep forever. Game over!");
                        }
                        else
                        {
                            Console.WriteLine($"Day {currentDay} has ended. You have {maxDays - currentDay} days left.\n");
                        }
                    }
                }

               
                


                if (currentDay == 4) // Day 4: Only Library is available
                {
                    Console.WriteLine("\nDay 4: The Library is now open to you.");
                    Console.WriteLine(library.RoomDescription);
                    Console.WriteLine("Type anything to enter the library and attempt to cure yourself, or type 'exit' to quit.");
                    string libChoice = Console.ReadLine().ToLower();
                    if (libChoice == "exit")
                    {
                        Console.WriteLine("You have chosen to exit the game. Goodbye!");
                        break;
                    }

                    int itemCount = inventory.Count;
                    if (itemCount >= 3)
                    {
                        Console.WriteLine("\nYou use all your collected items and the knowledge from the books. After a tense moment, you feel the curse lift. You are cured! You escape the castle, free at last. (Good Ending)");
                    }
                    else if (itemCount == 2)
                    {
                        Console.WriteLine("\nYou try to make do with only two items. The mixture backfires! You mutate into a strange creature, doomed to wander the castle forever. (Mutant Ending)");
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have enough items to make the cure. The curse overwhelms you, and you perish in the castle. (Bad Ending)");
                    }
                    break;
                }


            } 

            //else // Day 4: Only Library is available
            //{
            //    Console.WriteLine("\nDay 4: The Library is now open to you.");
            //    Console.WriteLine(library.RoomDescription);
            //    Console.WriteLine("Type anything to enter the library and attempt to cure yourself, or type 'exit' to quit.");
            //    string libChoice = Console.ReadLine().ToLower();
            //    if (libChoice == "exit")
            //    {
            //        Console.WriteLine("You have chosen to exit the game. Goodbye!");
            //        break;
            //    }

            //    int itemCount = inventory.Count;
            //    if (itemCount >= 3)
            //    {
            //        Console.WriteLine("\nYou use all your collected items and the knowledge from the books. After a tense moment, you feel the curse lift. You are cured! You escape the castle, free at last. (Good Ending)");
            //    }
            //    else if (itemCount == 2)
            //    {
            //        Console.WriteLine("\nYou try to make do with only two items. The mixture backfires! You mutate into a strange creature, doomed to wander the castle forever. (Mutant Ending)");
            //    }
            //    else
            //    {
            //        Console.WriteLine("\nYou don't have enough items to make the cure. The curse overwhelms you, and you perish in the castle. (Bad Ending)");
            //    }
            //    break;
            //}

            //Console.WriteLine(starterRoom.RoomDescription);
            //Console.WriteLine("a - Enter castle");
            //string desicion =Console.ReadLine();
            //if(desicion != "a")
            //{
            //    Console.WriteLine($"error. {desicion} is invalid. type in 'a'.");
            //}
            ////Interface
            //Console.Clear();

            ////Room rooms = starterRoom;

            //Console.WriteLine("a - Lab room");
            //Console.WriteLine("b - Kitchen");
            //Console.WriteLine("c - dining room");

            //string choice = Console.ReadLine();
            //choice = choice.ToLower();
            ////Room rooms = starterRoom;

            //if(choice == "a")
            //{
            //    Console.WriteLine($"Rooms you can enter");

            //    Console.WriteLine($" You entered {Lab.RoomName}. \n{Lab.RoomDescription}");
            //    Console.ReadLine();
            //    labNpc.labNPC();

            //    Console.WriteLine("go back?");
            //    string Input = Console.ReadLine();
            //    if(Input == "y")
            //    {
            //        //charac.Health--
            //        wizard.TakeDamage(25);
            //    }
            //}
            //else if (choice == "b")
            //{
            //    //Console.WriteLine(" would you like to go in the kitchen? y/n:");
            //    //string enterRoom = Console.ReadLine();

            //    Console.WriteLine($" You entered {Kitchen.RoomName}. \n{Kitchen.RoomDescription}");

            //    Console.ReadLine();
            //    kitchenNpc.kitchenNPC();
            //}
            //else if (choice == "c")
            //{
            //    Console.WriteLine($" You entered {diningRoom.RoomName}. \n{diningRoom.RoomDescription}");
            //    diningNpc.diningNPC();
            //}
            //else
            //{
            //    Console.WriteLine("invalid input. try again.");
            //}


            //Ending

            //if (!AllItems)
            //{
            //    Console.WriteLine("It is day 4 and you have not been able to find any items to make a cure. You die"); // bad ending 

            //}





            //while (rooms != null) 
            //{
            //Console.WriteLine(" would you like to go in the kitchen? y/n:");
            //string enterRoom = Console.ReadLine();

            //if (enterRoom == "y")
            //{
            //    Console.WriteLine($" you enter: {Kitchen.RoomName}. \n{Kitchen.RoomDescription}");
            //}
            //else if (enterRoom == "n")
            //{
            //    Console.WriteLine("You dont enter the kitchen.");

            //}
            //else 
            //{
            //    Console.WriteLine("invalid input.");
            //}


            //myNPC.Goodbye();
        }
    }
}
