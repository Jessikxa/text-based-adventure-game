using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBeestAdventure
{
    internal class InventorySystem
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void ListItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Inventory: empty");
            }
            else
            {
                Console.WriteLine("Inventory:");
                foreach (var item in items)
                {
                    Console.WriteLine($"- {item.Name}: {item.Description}");
                }
            }
        }


        public int Count => items.Count;
    }
}
