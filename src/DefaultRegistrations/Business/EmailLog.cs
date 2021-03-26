using DefaultRegistrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultRegistrations.Business
{
    public class EmailLog : ILog
    {
        private const string adminEmail = "admin@foo.com";
        public void Write(string message)
        {
            Console.WriteLine($"Email sent to {adminEmail} : {message}");
        }
    }
}
