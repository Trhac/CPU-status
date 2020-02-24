using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
    }
}
