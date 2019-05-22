using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BadCodeTestApp
{
    public class SearchCommand : ICommand
    {
        public string Path { get; }
        public SearchCommand(string path)
        {
            this.Path = path;
        }
        public void Execute()
        {
            Directory.GetFiles(Path, "*", SearchOption.AllDirectories).ToList().ForEach(n => Console.WriteLine(n));
        }
    }

    public class SearchCsCommand : ICommand
    {
        public string Path { get; }
        public SearchCsCommand(string path)
        {
            this.Path = path;
        }
        public void Execute()
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
    public class CreateTxtCommand : ICommand
    {
        public string Path { get; }
        public CreateTxtCommand(string path)
        {
            this.Path = path;
        }
        public void Execute()
        {
            File.Create(this.Path + "\\test.txt");
        }
    }

    public class DeleteTxtCommand : ICommand
    {
        public string Path { get; }
        public DeleteTxtCommand(string path)
        {
            this.Path = path;
        }
        public void Execute()
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

    public class ExitCommand : ICommand
    {
        public string Path { get; }

        public void Execute()
        {
            throw new Exception("Program has been interrupted");
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
                    return new SearchCommand(path);
                case "exit":
                    return new SearchCommand(path);
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
