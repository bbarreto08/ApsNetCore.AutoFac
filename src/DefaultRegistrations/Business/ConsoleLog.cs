using DefaultRegistrations.Interfaces;
using System;

namespace DefaultRegistrations.Business
{
    public class ConsoleLog : ILog, IConsole
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
