using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BadCodeTestApp
{
    class Program
    {

        static void Main(string[] args)
        {
            // string param = args[0];
            // string command = args[1];

            string path = @"D:\Own Scripts\с#\isd\BadCodeTestApp";
            string command = "search";

            CommandBuilder builder = CommandBuilder.GetCommandBuilder();

            ConsoleCommandManager manager = new ConsoleCommandManager();

            manager.SetCommand(builder.GetCommand(path, command));
            manager.ExecuteCommand();

            Console.ReadLine();
        }
    }
}
