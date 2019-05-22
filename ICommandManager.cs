using System.Collections.Generic;


namespace BadCodeTestApp
{
    public interface ICommandManager
    {
        int ExecuteCommand(IEnumerable<string> commands); 
    }
}