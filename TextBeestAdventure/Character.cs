using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextBeestAdventure 
{
    internal class Character 
    {
        public string Name;
        internal int Health;
        public int days = 4;
        public bool endOfDay = false;
        
        public Character(string name, int health)
        {
            Name = name;
            Health = health;
        }

        

        public void LoseHealth(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
           
        }

        public void DisplayHealth()
        {
            Console.WriteLine($"Wizard's Health: {Health}");
        }

        public void Days(int days) 
        {
            //Health = 100;

            if (days > 0)
            {
                days--;
                Console.WriteLine($"Days left:{days}");
                LoseHealth(25);
                
            }
            if( days <= 0 )
            {
                endOfDay = true;
                Console.WriteLine("You Died");
            }

        }
    }
}
