using System;

namespace BadCodeTestApp
{
    class MainWorker
    {
        public ConsoleCommandManager Manager { get; }
        public string Path { get; }
        private CommandBuilder Builder = CommandBuilder.GetCommandBuilder();
        public MainWorker(String path)
        {
            this.Manager = new ConsoleCommandManager();
            this.Path = path;
        }
        private string RichInput(string message)
        {
            System.Console.WriteLine(message);
            return Console.ReadLine();
        }

        public void Start()
        {
            while (true)
            {
                System.Console.WriteLine("Enter 'exit' to exit");
                System.Console.WriteLine("Enter 'help' to see all commands");
                string command = RichInput("Enter the command : ");
                this.Manager.SetCommand(Builder.GetCommand(this.Path, command));
                this.Manager.ExecuteCommand();
            }
        }
    }
}