using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBeestAdventure
{
    internal class NPCWithGoodbye : NPC
    {
        //public string Goodbye;
        public NPCWithGoodbye(string name, string interactiontext) : base(name, interactiontext)
        {
        }

        public void Goodbye()
        {
            Console.WriteLine("BYEEEEEE");
        }
    }
}
