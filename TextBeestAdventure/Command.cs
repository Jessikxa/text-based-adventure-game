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
        public Commands Accessor;
        public Action ExecuteCommand;
        
        //public int accesor
       
        //public enum commandoMando 
        //{
        //    Mando = 0,
        //    Jango = 1,
        //    AweesomeSacaue = 2,
        //}
        //public commandoMando mandodango;
        public Command(string  name, string info, Action executeCommand, Commands accessor) 
        {
            //mandodango = (commandoMando)Accessor;
            
            Name = name;
            Info = info;
            ExecuteCommand = executeCommand;
            Accessor = accessor;
            //executeCommand =  ExecuteCommand;
            
        }
        
        public enum Commands
        {
            Walk,
            Jump,
            sprint
        }
        
    }
}
