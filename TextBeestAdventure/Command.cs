using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBeestAdventure
{
    internal class Command
    {
        public string Name;
        public string Info;
        //public Action<string> Action;
        //action executeCommand
        public enum commandoMando 
        {
            Mando = 0,
            Jango = 1,
            AweesomeSacaue = 2,
        }
        public commandoMando mandodango;
        public Command(int Accessor, string info, string name) 
        {
            mandodango = (commandoMando)Accessor;
            Info = info;
            Name = name;
        }
    }
}
