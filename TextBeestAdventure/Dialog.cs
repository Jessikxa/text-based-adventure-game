using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBeestAdventure
{
    internal class Dialog
    {
        public void introduction()
        {
            Character wizard = new Character("Coran", 100);
            Console.WriteLine("");
            //Console.WriteLine("What is your name?:");
            //string wizardName = Console.ReadLine();

            Console.WriteLine($"You are a young wizard, named {wizard.Name} who has a curse they can't fix.");
            Console.WriteLine("Confused at first, finding out you cant cure yourself, you go and talk to the only person who knows everything but reveals only slithers.");

            Console.ReadLine();

            Console.WriteLine($"Sylvia, the phychic, reads her globe and tells {wizard.Name} they needs to go to the castle of Avidrian. \n'but beware', she says. 'Avidrian dates back thousands of years but is infested with the souls of thousands more. " +
                "\nYou will have to go through them before you can find what you seek'." +
                "\nEvery night you'll get a little more sick, until day seven, where you will succumb to your curse, \nunless you find the cure"); //background info ):
            Console.ReadLine();

            Console.WriteLine($"Knowing this information {wizard.Name} decides it is worth the risk and steps out of the phychic's room.");
            Console.Clear();
            Console.WriteLine("\n'Arghhh!! I don't feel so good at all. I'll need to hurry before it's too late' ");
            
            Console.ReadLine();
        }

        public void kitchenDialog()
        {
            Console.WriteLine("");
        }
    }
}
