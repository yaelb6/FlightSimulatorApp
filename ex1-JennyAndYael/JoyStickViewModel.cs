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
            double x, y;
            //Normalize 
            x = 2 * ((rudder - (-140.1)) / (140.1 - (-140.1))) - 1;
            y = 2 * ((elevator - (-140.1)) / (140.1 - (-140.1))) - 1;
            //simulatorModel.updateRudderAndElevator(rudder, elevator);
            simulatorModel.updateRudderAndElevator(x, y);
            Console.WriteLine("Moved! x=" + x + "y="+ y);
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
                Console.WriteLine("Throttle is updated!");
                
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
                Console.WriteLine("aileron is updated!");
            }
        }
    }
}