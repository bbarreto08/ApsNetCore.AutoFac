using Autofac;
using System;

namespace AutofacSamples
{
    public interface ILog
    {
        void Write(string message);
    }

    public class ConsoleLog : ILog
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

    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleLog>().As<ILog>().AsSelf();
            builder.RegisterType<Engine>();
            builder.RegisterType<Car>();

            IContainer container = builder.Build();

            var car = container.Resolve<Car>();
            car.Go();
        }
    }
}
