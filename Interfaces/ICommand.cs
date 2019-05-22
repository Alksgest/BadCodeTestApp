namespace BadCodeTestApp
{
    public interface ICommand
    {
        string Path { get; }
        void Execute();
    }
}