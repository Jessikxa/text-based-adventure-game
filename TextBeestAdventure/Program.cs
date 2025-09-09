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
            //NPC kitchenNpc = new NPC("wee");
            //NPC labNpc = new NPC("wee");
            //NPC diningNpc = new NPC("wee");
            Dialog meep = new Dialog();
           



            //rooms
            Room starterRoom = new Room("Castle Entrance", " You stand in front of Avidrian's doorway. \nWhen you look up, it seems as if the stone walls touch the sky. \nYou use the door knocker to knock three times. \nWhen knocking the third time, the door opens.");

            //starterRoom.add("north", 1);
            rooms.Add(starterRoom);
            //rooms[0].RoomFunctions();

            //room2
            Kitchen kitchenRoom = new Kitchen("The Kitchen", "If you can call it that, has rotten food caked on the floor and all surfaces, with loads of cobwebs. The smell is putrid and you become a little bit queasy. knives and pots are rusted. The only thing remotely clean are big wooden bowls.");
            //Kitchen.roomChoiceExit("east", 2);
            rooms.Add(kitchenRoom);

            //room3
            LabRoom Lab = new LabRoom("The Laboratorium", "flasks on the tables, with different coloured liquids, filled to differen levels. Books and pages littering the room. Some had gotton on the floor but most of the mess was on the tables and desk.");
            //Lab.roomChoiceExit("north", 3);
            rooms.Add(Lab);

            //room4
            Dining_Room diningRoom = new Dining_Room("The Dining Room", "The room is dusty but no apparent mess.");
            //diningRoom.roomChoiceExit("west", 4);
            rooms.Add(diningRoom);

            Room library = new Room("The Library", "on the brink of death you muster your way to the newly opened room. You enter the ancient library. Dusty tomes and mysterious books line the shelves. This is your last chance to find a cure using your knowledge and the items you've collected.");


            //Item potion = new Item("Potion", "A mysterious glowing potion.");
            //Item book = new Item("Book", "An old dusty spellbook.");
            //Item apple = new Item("Apple", "A fresh red apple.");
            Item goatsEye = new Item("Goats Eye", "Has the same look that all the trapped souls have.");
            Item fur = new Item("fur", "Soft and fluffy, taken from a boy's teddy bear.");
            Item flask = new Item("flask", "A small glass container filled with a pink liquid.");

            kitchenRoom.Items.Add(goatsEye);
            Lab.Items.Add(flask);
            diningRoom.Items.Add(fur);
            


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
            
            bool intro = true;

            while(intro)
            {
                Console.WriteLine("Type 'start' to begin your adventure or 'exit' to quit:");
                string startInput = Console.ReadLine().ToLower();
                if (startInput == "start")
                {
                    intro = false;
                }
                else if (startInput == "exit")
                {
                    Console.WriteLine("Exiting the game. Goodbye!");
                    return; // Exit the program
                }
                else
                {
                    Console.WriteLine("Invalid input. Please type 'start' or 'exit'.");
                }
            }
            //Console.WriteLine(starterRoom.RoomDescription);
            //Console.WriteLine("a - Enter castle");
            //string desicion = Console.ReadLine().ToLower();
            //if (desicion != "a")
            //{
            //    Console.WriteLine($"error. {desicion} is invalid. type in 'a'.");
            //}

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
                    Console.WriteLine("\n");
                    wizard.DisplayHealth();
                    inventory.ListItems();
                    Console.WriteLine("");
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
                    Console.WriteLine($" You entered {Lab.RoomName}. \n{Lab.RoomDescription}");

                    Console.ReadLine();
                    Lab.RoomFunctions(inventory);
                    validOption = true;

                }
                else if (choice == "east")
                {
                    currentRoomIndex = rooms.IndexOf(kitchenRoom);
                    Console.WriteLine($" You entered {kitchenRoom.RoomName}. \n{kitchenRoom.RoomDescription}");
                    Console.ReadLine();
                    kitchenRoom.RoomFunctions(inventory);
                    validOption = true;
                }
                else if (choice == "west")
                {
                    currentRoomIndex = rooms.IndexOf(diningRoom);
                    Console.WriteLine($" You entered {diningRoom.RoomName}. \n{diningRoom.RoomDescription}");
                    
                    //diningNpc.diningNPC();
                    diningRoom.RoomFunctions(inventory);
                    validOption = true;

                }
                else
                {
                    Console.WriteLine("invalid input. try again.");
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
