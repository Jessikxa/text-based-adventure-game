using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBeestAdventure
{
    internal class Room
    {
        public string Name;
        //public string Doors;

        List<Room> RoomsAllowedToGoTo;

        public Room(string roomName, int bing) 
        {
            Name = roomName;
            RoomsAllowedToGoTo = new List<Room>(bing);
        }
    }
}
