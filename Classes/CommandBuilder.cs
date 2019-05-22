

namespace BadCodeTestApp
{
    public class CommandBuilder
    {
        private CommandBuilder() { }
        private static CommandBuilder Builder;

        public static CommandBuilder GetCommandBuilder()
        {
            if (Builder == null)
            {
                Builder = new CommandBuilder();
                return Builder;
            }
            else
                return Builder;
        }
        public ICommand GetCommand(string path, string command)
        {
            switch (command.ToLower())
            {
                case "help":
                    return new HelpCommand(path);
                case "exit":
                    return new ExitCommand(path);
                case "search":
                    return new SearchCommand(path);
                case "cs_search":
                    return new SearchCsCommand(path);
                case "create_txt":
                    return new CreateTxtCommand(path);
                case "remove_txt":
                    return new DeleteTxtCommand(path);
                default:
                    return new DefaultCommand(path);
            }
        }
    }
}