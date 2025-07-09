using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Hardware.Info;
using HardwareProviders.CPU;

namespace WPF_showcase.Models
{
    [Serializable]
    class CPUStatus : INotifyPropertyChanged
    {

        private double temperature;
        public double Temperature
        {
            get { return temperature; }
            set 
            { 
                temperature = value;
                NotifyPropertyChanged();
            }
        }

        private double load;
        public double Load
        {
            get { return load; }
            set
            {
                load = value;
                NotifyPropertyChanged();
            }
        }
        private double clock;
        public double Clock
        {
            get { return clock; }
            set
            {
                clock = value;
                NotifyPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Update(Cpu[] cpu)
        {
            var usableData = cpu.FirstOrDefault();
            if (usableData != null)
            {
                Temperature = usableData.PackageTemperature?.Value.Value ?? -1;
                Load = usableData.TotalLoad?.Value.Value ?? -1;
                Clock = usableData.CoreClocks?.Max(x => x.Value.Value) ?? -1;
            }
            else
            {
                Temperature = 0;
                Load = 0;
                Clock = 0;
            }
        }

        public void Update(HardwareInfo hardwareInfo)
        {
            var cpu = hardwareInfo.CpuList.FirstOrDefault();
            if (cpu != null)
            {
                Clock = cpu.CurrentClockSpeed;
                Load = cpu.PercentProcessorTime;
            }
        }
    }
}
