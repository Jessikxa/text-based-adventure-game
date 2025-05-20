using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBeestAdventure
{
    internal class Character
    {
        public string Name;
        public int xpLevel;
        List<Character> characters = new List<Character>();
        public Character(string name, int XpLevel)
        {
            Name = name;
            xpLevel = XpLevel;
        }

        public void chooseCharacter(List<Character> characters) 
        {
        }
    }
}
