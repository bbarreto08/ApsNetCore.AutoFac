using ScenarioWithoutDI.Interfaces;
using System;

namespace ScenarioWithoutDI.Business
{
    public class ConsoleLog : ILog
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
