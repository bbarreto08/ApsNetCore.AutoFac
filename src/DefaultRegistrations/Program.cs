using Autofac;
using DefaultRegistrations.Business;
using DefaultRegistrations.Interfaces;
using DefaultRegistrations.Models;
using System;

namespace DefaultRegistrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EmailLog>().As<ILog>();
            builder.RegisterType<ConsoleLog>().As<ILog>()
                                              .As<IConsole>()
                                              .PreserveExistingDefaults();

            builder.RegisterType<Engine>();
            builder.RegisterType<Car>();

            IContainer container = builder.Build();

            var car = container.Resolve<Car>();
            car.Go();
        }
    }
}
