using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ex1_JennyAndYael
{
    class JoyStickViewModel : INotifyPropertyChanged
    {
        private MyModel simulatorModel;
        private double rudder;
        private double elevator;
        private double throttle;
        private double aileron;
        public event PropertyChangedEventHandler PropertyChanged;
        public JoyStickViewModel(MyModel model)
        {
            this.simulatorModel = model;
        }
        public double VM_Rudder
        {
            get
            {
                return this.rudder;
            }
            set
            {
                rudder = value;
            }
        }
        public double VM_Elevator
        {
            get
            {
                return this.elevator;
            }
            set
            {
                elevator = value;
            }
        }
        public double VM_Throttle
        {
            get
            {
                return this.throttle;
            }
            set
            {
                throttle = value;
            }
        }
        public double VM_Aileron
        {
            get
            {
                return this.aileron;
            }
            set
            {
                aileron = value;
            }
        }
    }
}