using System;
using NextUp.MultiScenario;

namespace NextUpConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const string scbase = "Base scenario";
            const string sc1 = "Scenario 1";
            var obj1 = new SampleObject();
            var obj2 = new SampleObject();
            var sm = SampleObject.ScenarioManager = new ScenarioManager(scbase);
            obj1.SampleProperty = 1;
            obj2.SampleProperty = 2;

            sm.CurrentScenario = sc1;
            obj1.SampleProperty = 3;
            obj2.SampleProperty = 4;

            Console.WriteLine("sc1");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");

            sm.CurrentScenario = scbase;
            Console.WriteLine("Base scenario");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");

            sm.CurrentScenario = sc1;
            Console.WriteLine("sc1");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");
        }
    }
}
