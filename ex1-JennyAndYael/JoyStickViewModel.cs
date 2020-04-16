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
        private string throttle = "0";
        private string aileron = "0";
        private double rudder;
        private double elevator;

        public event PropertyChangedEventHandler PropertyChanged;
        //This method defines the view model's model to be the given model.
        public JoyStickViewModel(MyModel model)
        {
            this.simulatorModel = model;
        }
        //This method defines the actions when the joystick moves.
        public void JoyStickMoved(double rudder, double elevator)
        {
            double x, y;
            //Normalize the data to be between -1 to 1.
            x = 2 * ((rudder - (-140.1)) / (140.1 - (-140.1))) - 1;
            y = 2 * ((elevator - (-140.1)) / (140.1 - (-140.1))) - 1;
            simulatorModel.updateRudderAndElevator(x, y);
            this.rudder = x;
            this.elevator = y;
            NotifyPropertyChanged("VM_" + "rudder");
            NotifyPropertyChanged("VM_" + "elevator");
        }
        //This method update that the propName changed.
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public string VM_Throttle
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
                simulatorModel.updateThrottle(Double.Parse(throttle));

            }
        }
        public string VM_Aileron
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
                simulatorModel.updateAileron(Double.Parse(aileron));
            }
        }
        public string VM_rudder
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
        public string VM_elevator
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