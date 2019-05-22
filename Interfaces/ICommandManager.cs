using System.Collections.Generic;


namespace BadCodeTestApp
{
    public interface ICommandManager
    {
        void ExecuteCommand(); 
        void SetCommand(ICommand command);
    }
}