using System;
using System.ComponentModel;

namespace FlightSimulator
{
    public class JoyStickViewModel : INotifyPropertyChanged
    {
        private MyModel simulatorModel;
        private string throttle = "0";
        private string aileron = "0";
        private double rudder;
        private double elevator;

        public event PropertyChangedEventHandler PropertyChanged;
        public JoyStickViewModel(MyModel model)
        {
            this.simulatorModel = model;
        }
        public void JoyStickMoved(double rudder, double elevator)
        {
            double x, y;
            //Normalize 
            x = 2 * ((rudder - (-140.1)) / (140.1 - (-140.1))) - 1;
            y = 2 * ((elevator - (-140.1)) / (140.1 - (-140.1))) - 1;
            //simulatorModel.updateRudderAndElevator(rudder, elevator);
            simulatorModel.UpdateRudderAndElevator(x, y);
            this.rudder = x;
            this.elevator = y;
            NotifyPropertyChanged("Vm" + "Rudder");
            NotifyPropertyChanged("Vm" + "Elevator");
        }
        public void NotifyPropertyChanged(string propName)
        {
            //paul's example, if it doesn't work try like eli's example
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public string VmThrottle
        {
            get
            {
                if (this.throttle.Length > 5)
                {
                    return this.throttle.Substring(0, 5);
                }
                else
                {
                    return this.throttle;
                }
            }
            set
            {
                this.throttle = value;
                simulatorModel.UpdateThrottle(Double.Parse(throttle));

            }
        }
        public string VmAileron
        {
            get
            {
                if (aileron.Length > 5)
                {
                    return this.aileron.Substring(0, 5);
                }
                else
                {
                    return this.aileron;
                }

            }
            set
            {
                aileron = value;
                simulatorModel.UpdateAileron(Double.Parse(aileron));
            }
        }
        public string VmRudder
        {
            get
            {
                if (rudder.ToString().Length > 5)
                {
                    return rudder.ToString().Substring(0, 5);
                }
                else
                {
                    return rudder.ToString();
                }
            }
        }
        public string VmElevator
        {
            get
            {
                if (elevator.ToString().Length > 5)
                {
                    return elevator.ToString().Substring(0, 5);
                }
                else
                {
                    return elevator.ToString();
                }
            }
        }
    }
}