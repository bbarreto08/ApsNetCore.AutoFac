using RegisteringTypes.Interfaces;
using System;

namespace RegisteringTypes.Business
{
    public class ConsoleLog : ILog
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
