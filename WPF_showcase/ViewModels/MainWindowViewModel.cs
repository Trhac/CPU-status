using Hardware.Info;
using HardwareProviders.CPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WPF_showcase.Models;

namespace WPF_showcase.ViewModels
{
    class MainWindowViewModel
    {
        public CPUStatus ActualStatus { get; }

        private Timer timer;
        private readonly HardwareInfo hardwareInfo;

        public MainWindowViewModel()
        {
            
            hardwareInfo = new HardwareInfo();

            ActualStatus = new CPUStatus();
            timer = new Timer(2_000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            /*
            Double CPUtprt = 0;
            System.Management.ManagementObjectSearcher mos = new System.Management.ManagementObjectSearcher(@"root\WMI", "Select * From MSAcpi_ThermalZoneTemperature");
            foreach (System.Management.ManagementObject mo in mos.Get())
            {
                CPUtprt = Convert.ToDouble(Convert.ToDouble(mo.GetPropertyValue("CurrentTemperature").ToString()) - 2732) / 10;
                //Console.WriteLine("CPU temp : " + CPUtprt.ToString() + " °C");
                ActualStatus.Temperature = CPUtprt;
            } 
            */
            /*
            var m_CPUCounter = new System.Diagnostics.PerformanceCounter();
            m_CPUCounter.CategoryName = "Processor";
            m_CPUCounter.CounterName = "% Processor Time";
            m_CPUCounter.InstanceName = "_Total";
            var values = m_CPUCounter.NextValue();

            var cpu = Cpu.Discover();
            ActualStatus.Update(cpu);

            ActualStatus.Load = values;
            */
            hardwareInfo.RefreshCPUList();
            ActualStatus.Update(hardwareInfo);
        }
    }
}
