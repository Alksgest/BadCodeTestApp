using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BadCodeTestApp
{

    public abstract class Command : ICommand
    {
        protected static List<string> Commands = new List<string> {
            "help",
            "exit",
            "search", 
            "cs_search",
            "create_txt",
            "remove_txt",      
        };
        public string Path { get; }
        public Command(string path)
        {
            this.Path = path;
        }

        public abstract void Execute();
    }
    public class SearchCommand : Command
    {
        public SearchCommand(string path) : base(path) { }
        public override void Execute()
        {
            Directory.GetFiles(Path, "*", SearchOption.AllDirectories).ToList().ForEach(n => Console.WriteLine(n));
        }
    }

    public class SearchCsCommand : Command
    {
        public SearchCsCommand(string path) : base(path) { }
        public override void Execute()
        {
            List<string> strs = Directory.GetFiles(Path, "*", SearchOption.AllDirectories).ToList();
            foreach (string str in strs)
            {
                if (str.Substring(str.LastIndexOf(".") + 1) == "cs")
                {
                    ConsoleLogger.Logger.Log(str, null, null);
                }
            }
        }
    }
    public class CreateTxtCommand : Command
    {
        public CreateTxtCommand(string path) : base(path) { }
        public override void Execute()
        {
            File.Create(this.Path + "\\test.txt");
        }
    }

    public class DeleteTxtCommand : Command
    {
        public DeleteTxtCommand(string path) : base(path) { }
        public override void Execute()
        {
            string fullPath = this.Path + "\\test.txt";
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            else
                throw new FileNotFoundException("File does not exist!");
        }
    }

    public class ExitCommand : Command
    {
        public ExitCommand(string path) : base(path) { }
        public override void Execute()
        {
            throw new Exception("Program has been interrupted");
        }
    }

    public class HelpCommand : Command
    {
        public HelpCommand(string path) : base(path) { }
        public override void Execute()
        {
            foreach(var command in Command.Commands)
            ConsoleLogger.Logger.Log(command, null, null);
        }
    }

    public class CommandBuilder
    {
        private CommandBuilder() { }
        private static CommandBuilder Builder;

        public static CommandBuilder GetCommandBuilder()
        {
            return Builder == null ? new CommandBuilder() : Builder;
        }
        public ICommand GetCommand(string path, string command)
        {
            switch (command)
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
                    return new SearchCommand(path);
                case "remove_txt":
                    return new SearchCommand(path);
            }
            return null;
        }
    }
}
