using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TextBeestAdventure
{
    internal class Command
    {
        public string Name;
        public string Info;
        Action<string> executeCommand = womp =>; 
        
        //public int accesor
        //public Action<string> Action;
        //action executeCommand
        public enum commandoMando 
        {
            Mando = 0,
            Jango = 1,
            AweesomeSacaue = 2,
        }
        public commandoMando mandodango;
        public Command(int Accessor, string info, string name, Action ExecuteCommand) 
        {
            mandodango = (commandoMando)Accessor;
            Info = info;
            Name = name;
            //executeCommand =  ExecuteCommand;
            
        }
        
        
    }
}
