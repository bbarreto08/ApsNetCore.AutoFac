using Autofac;
using RegisteringTypes.Interfaces;
using RegisteringTypes.Models;
using System;

namespace RegisteringTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleLog>().As<ILog>().AsSelf();
            builder.RegisterType<Engine>();
            builder.RegisterType<Car>();

            IContainer container = builder.Build();

            var log = container.Resolve<ConsoleLog>();

            var car = container.Resolve<Car>();
            car.Go();
        }
    }
}
