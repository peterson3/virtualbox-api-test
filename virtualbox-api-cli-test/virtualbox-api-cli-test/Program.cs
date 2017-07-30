using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualBox;

namespace virtualbox_api_cli_test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IVirtualBox vbox = new VirtualBox.VirtualBox();
            string menuChoice = "1";

            while (menuChoice != "0")
            {
                Console.WriteLine();
                Console.WriteLine("*****************************");
                Console.WriteLine("****VIRTUALBOX API TESTING***");
                Console.WriteLine("*****************************");
                Console.WriteLine("\n");
                Console.WriteLine("1- List VirtualBoxes");
                Console.WriteLine("2- Open");
                Console.WriteLine("0- Quit");
                Console.Write("\nOpt: ");
                menuChoice = Console.ReadLine();
                Console.WriteLine();

                switch (menuChoice)
                {
                    case "1":
                        Console.WriteLine("List of all VirtualBox...");
                        foreach (IMachine machine in vbox.Machines)
                        {
                            Console.WriteLine(" {");
                            Console.WriteLine("\tName: " + machine.Name +",");
                            Console.WriteLine("\tState: " + machine.State + ",");
                            Console.WriteLine("\tDescription: " + machine.Description + ",");
                            Console.WriteLine("\tSessionName: " + machine.SessionName + ",");
                            Console.WriteLine("\tFrontEndName: " + machine.DefaultFrontend + ",");
                            Console.WriteLine("\tOSTypeId: " + machine.OSTypeId);
                            Console.WriteLine(" }");
                        }

                        break;
                    case "2":
                        // IMachine ubuntuBox = 
                        Console.Write("Type Machine Name:");
                        string chosenMachineName = Console.ReadLine();
                        IMachine chosenMachine = vbox.FindMachine(chosenMachineName);
                        //chosenMachine.ShowConsoleWindow();
                        IProgress progress = chosenMachine.LaunchVMProcess(new Session(), "", "");
                        Console.WriteLine(progress.Description);
                        break;
                    default:
                        Console.WriteLine("Select Valid Option");
                        break;

                }
            }


        }
    }
}
