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
        public NPCWithGoodbye( string interactiontext) : base( interactiontext)
        {
        }

        public void Goodbye()
        {
            Console.WriteLine("BYEEEEEE");
        }

        public override void Talk()
        {
            base.Talk();
            Console.WriteLine("it is now CHANGED");
        }
    }
}
