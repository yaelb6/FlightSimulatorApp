using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ex1_JennyAndYael
{
    public class JoyStickViewModel : INotifyPropertyChanged
    {
        private MyModel simulatorModel;
        private double throttle;
        private double aileron;
        public event PropertyChangedEventHandler PropertyChanged;
        public JoyStickViewModel(MyModel model)
        {
            this.simulatorModel = model;
        }
        public void joyStickMoved(double rudder, double elevator)
        {
            simulatorModel.updateRudderAndElevator(rudder, elevator);
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
                simulatorModel.updateThrottle(throttle);
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
                simulatorModel.updateAileron(aileron);
            }
        }
    }
}