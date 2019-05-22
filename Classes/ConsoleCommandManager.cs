using System.Collections.Generic;


namespace BadCodeTestApp
{
    public class ConsoleCommandManager : ICommandManager
    {
        ICommand Command;
        public ConsoleCommandManager() { }
        public void SetCommand(ICommand command)
        {
            this.Command = command;
        }
        public void ExecuteCommand()
        {
            this.Command?.Execute();
        }
    }
}