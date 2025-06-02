using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBeestAdventure
{
    internal class NPC
    {
        public string Name;
        public string InteractionText;

        public NPC(string name, string interactiontext)
        {
            Name = name;
            InteractionText = interactiontext;
        }

        public void Talk()
        {
            Console.WriteLine($"{Name}:{InteractionText}");
        }
    }
}

    

