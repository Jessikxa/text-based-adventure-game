using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBeestAdventure
{

    public enum Directions {
        North,
        South,
        East,
        West
    }
    internal class Room
    {
        public string RoomName;
        public string RoomDescription;
        public Dictionary<Directions, Room> Exits {  get; set; }
        public string CurrentRoom;
        public List<Item> Items { get; set; }
        //public List<Room> RoomsAllowedToGoTo { get; set; }

        public Room(string roomName, string roomDescription)
        {
            RoomName = roomName;
            RoomDescription = roomDescription;
            Exits = new Dictionary<Directions, Room>();
            Items = new List<Item>();
            //RoomsAllowedToGoTo = new List<Room>();
        }

        public void addExit(Directions direction, Room nextRoom)
        {
            {
                Exits[direction] = nextRoom;

            }
        }

        public virtual void RoomFunctions()
        {

        }
    }
}
