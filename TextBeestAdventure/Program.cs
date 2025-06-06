using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextBeestAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string displayName = Console.ReadLine();
            //string displayInteractionText = Console.ReadLine();
            //displayName,displayInteractionText
            //NPC myNPC = new NPC("Jessica", "hoi ik ben jessica");

            //NPC npc = new NPC("Kirby", " Hi im kirby");
            NPCWithGoodbye myNPC = new NPCWithGoodbye("Jessica", " hoi ik ben jessica");


            //npc.Talk();

            myNPC.Talk();
            //myNPC.Goodbye();
        }
    }
}
