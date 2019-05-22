using System;


namespace BadCodeTestApp
{
    public class InterruptException : Exception
    {
        public InterruptException() : base("Program has been interrupted.") {}
    }
}