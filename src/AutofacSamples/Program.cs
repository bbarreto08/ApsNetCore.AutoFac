using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;

namespace AutofacSamples
{
    public interface ILog
    {
        void Write(string message);
    }

    public interface IConsole
    {

    }

    public class ConsoleLog : ILog, IConsole
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Engine
    {
        private int id;
        private ILog log;

        public Engine(ILog log)
        {
            this.id = new Random().Next();
            this.log = log;
        }

        public void Ahead(int power)
        {
            log.Write($"Engine [{id}] ahead {power}");
        }
    }

    public class Car
    {
        private ILog log;
        private Engine engine;

        public Car(Engine engine)
        {
            this.engine = engine;
            this.log = new EmailLog();
        }

        public Car(Engine engine, ILog log)
        {
            this.log = log;
            this.engine = engine;
        }

        public void Go()
        {
            engine.Ahead(100);
            log.Write("Car going forward...");
        }
    }

    public class EmailLog : ILog
    {
        const string adminEmail = "admin@teste.com";
        public void Write(string message)
        {
            Console.WriteLine($"Email enviado = {message}");
        }
    }

    public class SMSLog : ILog
    {
        private string phoneNumber;

        public SMSLog(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public void Write(string message)
        {
            Console.WriteLine($"SMS to {phoneNumber} : {message}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            // Named parameter
            //builder.RegisterType<SMSLog>()
            //    .As<ILog>()
            //    .WithParameter("phoneNumber", "123456789");

            // type parameter
            //builder.RegisterType<SMSLog>()
            //    .As<ILog>()
            //    .WithParameter(new TypedParameter(typeof(string), "12345678"));

            // Resolve paramenter
            //builder.RegisterType<SMSLog>()
            //    .As<ILog>()
            //    .WithParameter(
            //        new ResolvedParameter(
            //            (pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "phoneNumber",
            //            (pi, ctx) => "12345678"
            //        )
            //    );

            Random random = new Random();
            builder.Register((c, p) => new SMSLog(p.Named<string>("phoneNumber")))
                .As<ILog>();

            Console.WriteLine("Builde container");
            var container = builder.Build();

            var log = container.Resolve<ILog>(new NamedParameter("phoneNumber", random.Next().ToString()));

            log.Write("Testing");
        }
    }
}
