using System;
using NextUp.MultiScenario;

namespace NextUpConsoleTest
{
    class Program
    {
        static void SimpleScenariosTest()
        {
            const string scbase = "Base scenario";
            const string sc1 = "Scenario 1";
            var sm = SampleObject.ScenarioManager = new ScenarioManager(scbase);

            var obj1 = new SampleObject();
            var obj2 = new SampleObject();
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

        static void XpScenariosTest()
        {
            var scbase = new XpScenario();
            var scchild1 = new XpScenario();
            var scchild11 = new XpScenario();
            var scchild2 = new XpScenario();
            scbase.AddChild(scchild1);
            scchild1.AddChild(scchild11);
            scbase.AddChild(scchild2);

            var sm = SampleObject.ScenarioManager = new ScenarioManager(scbase);

            var obj1 = new SampleObject();
            var obj2 = new SampleObject();
            obj1.SampleProperty = 1;
            obj2.SampleProperty = 2;

            sm.CurrentScenario = scchild1;
            obj1.SampleProperty = 3;
            obj2.SampleProperty = 4;

            sm.CurrentScenario = scchild11;
            obj1.SampleProperty = 5;
            obj2.SampleProperty = 6;

            sm.CurrentScenario = scchild2;
            obj1.SampleProperty = 7;
            obj2.SampleProperty = 8;


            Console.WriteLine("init");

            sm.CurrentScenario = scbase;
            Console.WriteLine("scbase");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");

            sm.CurrentScenario = scchild1;
            Console.WriteLine("scchild1");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");

            sm.CurrentScenario = scchild11;
            Console.WriteLine("scchild11");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");

            sm.CurrentScenario = scchild2;
            Console.WriteLine("scchild2");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");

            obj1.SampleProperty = 9;
            obj2.SampleProperty = 10;

            Console.WriteLine("change1");

            sm.CurrentScenario = scbase;
            Console.WriteLine("scbase");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");

            sm.CurrentScenario = scchild1;
            obj1.SampleProperty = 11;
            obj2.SampleProperty = 12;

            Console.WriteLine("change2");

            Console.WriteLine("scchild1");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");

            sm.CurrentScenario = scchild11;
            Console.WriteLine("scchild11");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");

            sm.CurrentScenario = scchild2;
            Console.WriteLine("scchild2");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");

            sm.CurrentScenario = scbase;
            Console.WriteLine("scbase");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");

            sm.CurrentScenario = scchild2;
            Console.WriteLine("scchild2");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");

            sm.CurrentScenario = scbase;
            obj1.SampleProperty = 13;
            obj2.SampleProperty = 14;

            Console.WriteLine("change3");

            Console.WriteLine("scbase");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");

            sm.CurrentScenario = scchild1;
            Console.WriteLine("scchild1");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");

            sm.CurrentScenario = scchild11;
            Console.WriteLine("scchild11");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");

            sm.CurrentScenario = scchild2;
            Console.WriteLine("scchild2");
            Console.WriteLine($"obj1 = {obj1.SampleProperty}");
            Console.WriteLine($"obj2 = {obj2.SampleProperty}");
        }

        static void Main(string[] args)
        {
            XpScenariosTest();
        }
    }
}
