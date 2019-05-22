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
            string path = args[0];
            //string command = args[1];
            MainWorker worker = new MainWorker(new ConsoleCommandManager(), path);

            worker.Start();
        }
    }
}
