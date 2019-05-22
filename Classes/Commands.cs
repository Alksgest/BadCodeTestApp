using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BadCodeTestApp
{

    public abstract class Command : ICommand
    {
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
            TextLogger.GetLogger().Log($"Method {this.GetType().ToString()}.Execute() has been invoked", this.Path);
            Directory.GetFiles(Path, "*", SearchOption.AllDirectories).ToList().ForEach(n => Console.WriteLine(n));
            System.Console.WriteLine("\n"); 
        }
    }

    public class SearchCsCommand : Command
    {
        public SearchCsCommand(string path) : base(path) { }
        public override void Execute()
        {
            TextLogger.GetLogger().Log($"Method {this.GetType().ToString()}.Execute() has been invoked", this.Path);
            List<string> strs = Directory.GetFiles(Path, "*", SearchOption.AllDirectories).ToList();
            foreach (string str in strs)
            {
                if (str.Substring(str.LastIndexOf(".") + 1) == "cs")
                {
                    System.Console.WriteLine(str);
                }
            }
            System.Console.WriteLine("\n");
        }
    }
    public class CreateTxtCommand : Command
    {
        public CreateTxtCommand(string path) : base(path) { }
        public override void Execute()
        {
            File.Create(this.Path + "\\test.txt").Dispose();
        }
    }

    public class DeleteTxtCommand : Command
    {
        public DeleteTxtCommand(string path) : base(path) { }
        public override void Execute()
        {
            TextLogger.GetLogger().Log($"Method {this.GetType().ToString()}.Execute() has been invoked", this.Path);
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
            TextLogger.GetLogger().Log($"Method {this.GetType().ToString()}.Execute() has been invoked", this.Path);
            throw new InterruptException();
        }
    }

    public class HelpCommand : Command
    {
         private readonly List<string> Commands = new List<string> {
            "help",
            "exit",
            "search",
            "cs_search",
            "create_txt",
            "remove_txt",
        }; 
        public HelpCommand(string path) : base(path) { }
        public override void Execute()
        {
            TextLogger.GetLogger().Log($"Method {this.GetType().ToString()}.Execute() has been invoked", this.Path);
            System.Console.Write("Commands : ");
            foreach (var command in this.Commands)
            {
                System.Console.Write(command + ", ");
            }
            System.Console.WriteLine("\n");
        }
    }

    public class DefaultCommand : Command
    {
        public DefaultCommand(string path) : base(path) { }
        public override void Execute()
        {
            TextLogger.GetLogger().Log($"Method {this.GetType().ToString()}.Execute() has been invoked", this.Path);
            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleLogger.GetLogger().Log("Invalid command", null);
            Console.ResetColor();
        }
    }

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
