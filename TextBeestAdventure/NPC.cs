using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TextBeestAdventure
{
    internal class NPC
    {
        //public string Name;
        public string InteractionText;

        public NPC(string interactiontext)
        {
            //Name = name;
            InteractionText = interactiontext;
        }

        public void kitchenNPC() //kitchen npc dialog
        {
            InteractionText = "At first you only see the room but after a minute or so of looking around you hear a voice and turn around frightened." +

            "'WHAT DO YOU THINK YOU'RE DOING HERE?'" +"A soul, shaking in anger, which a cleaver in hand";

            NPC kitchen = new NPC(InteractionText);
            Console.WriteLine(kitchen.InteractionText);

            Console.WriteLine("What do you answer:");

            Console.WriteLine("a - \"Looking around for something\"");
            Console.WriteLine("b - \"None of your business\"");  

            string Choice = Console.ReadLine();

            if(Choice == "a")
            {
                Console.WriteLine();
                //{ you be questioned further but will most likely will get an item}
            }
            if(Choice == "b")
            {
                Console.WriteLine();
                //    you will be met with more anger and given nothing. every time you try to enter the room you will be denied}
            }

        

            
            
        }

        public void labNPC()
        {
            InteractionText = "As soon as you enter you see a few souls hanging around a desk, looking at notes on the desk, chatting with each other about a certain formulas . A few more discussing and writing stuff on the chalkboard. all noice in the room stops and they stare at the door.\r\n\r\n\"who are you?\" one says. \"what are you doing here?\" another says, louder.\r\n";

            Console.WriteLine(" a - \"who are you?!\"");
            Console.WriteLine(" b - \"my name is {wizardName} and i'm cursed you see. i have come to find a cure. Can you help me?\"");

            //if (a)
            //{ You will be met with hostility and not given an item.or a bad item(maybe implement later in game)}

            //if (b)
            //{ The souls will be more willing to help and give you an item}

            NPC lab = new NPC(InteractionText);
            Console.WriteLine(lab.InteractionText);
        }

        public void diningNPC()
        {
            InteractionText = "You see a soul sitting on one of the chairs at the dining table, twirling her hair whilst looking \r\nuninterested and kicking her feet. Another wearing a long, fluffly see through boa, using a knife \r\nand fork, cutting into an empty place. A few others standing around looking at the artwork, or \r\npicking up items on the drawers.\r\n\r\nThey don't seem to care that you have entered into their space. Not giving you the time of day, \r\nyou decide to keep walking further into the room and ask the little boy, who you presume is sitting \r\nnext to their mother and the only person who looked up, if he new anything.\r\n";

            Console.WriteLine("a - \"Hello there, im not feeling so well. can you maybe help me?\"");

            Console.WriteLine("b - \"I need answers now!\"");
           

            //if (a)
            //{ the child will help you and show hit teddy.He will also give you an item}


            //if (b)
            //{ You will have frightened the child and he will hug his teddy and his mother, who will give you a dirty look.you wont receive an item}


            NPC dining = new NPC(InteractionText);
            Console.WriteLine(dining.InteractionText);
        }
        public virtual void Talk()
        {
            Console.WriteLine($"{InteractionText}");
        }


    }
}

    

