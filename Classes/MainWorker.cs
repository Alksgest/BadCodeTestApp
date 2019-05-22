using System;

namespace BadCodeTestApp
{
    class MainWorker
    {
        public ICommandManager Manager { get; }
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
            bool flag = true;
            System.Console.Clear();
            while (flag)
            {
                System.Console.WriteLine("Enter 'exit' to exit");
                System.Console.WriteLine("Enter 'help' to see all commands");
                string command = RichInput("Enter the command : ");
                this.Manager.SetCommand(Builder.GetCommand(this.Path, command));
                try
                {
                    this.Manager.ExecuteCommand();
                }
                catch (InterruptException e)
                {
                    TextLogger.GetLogger().Log(e.Message, this.Path);
                    flag = false;
                }
                catch (Exception e)
                {
                    TextLogger.GetLogger().Log(e.Message, this.Path);
                }
            }
        }
    }
}