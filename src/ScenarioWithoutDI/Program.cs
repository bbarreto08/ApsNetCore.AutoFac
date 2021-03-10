using ScenarioWithoutDI.Business;
using ScenarioWithoutDI.Models;

namespace ScenarioWithoutDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new ConsoleLog();
            var engine = new Engine(log);
            var car = new Car(engine, log);
            car.Go();
        }
    }
}
