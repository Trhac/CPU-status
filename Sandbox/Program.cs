using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardwareProviders.CPU;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var cpu = Cpu.Discover();
            var i = 0;
            foreach (var item in cpu)
            {
                Console.WriteLine($":: cpu#{i}::");
                Console.WriteLine(item.Identifier);
                Console.WriteLine(item.Name);                

                foreach (var temp in item.CoreTemperatures)
                {
                    Console.WriteLine($"Core temperature: {temp}");
                }

                Console.WriteLine($"Package temperature: {item.PackageTemperature}");                

                Console.WriteLine(item.TotalLoad);

                foreach (var voltage in item.CoreVoltages)
                {
                    Console.WriteLine($"voltage: {voltage}");
                }
                
            }
            Console.ReadKey();
        }
    }
}
