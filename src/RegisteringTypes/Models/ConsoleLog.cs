using RegisteringTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegisteringTypes.Models
{
    public class ConsoleLog : ILog
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
