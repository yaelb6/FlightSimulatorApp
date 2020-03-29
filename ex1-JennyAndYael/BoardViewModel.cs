using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ex1_JennyAndYael
{
    class BoardViewModel : INotifyPropertyChanged
    {
        private MyModel simulatorModel;
        public event PropertyChangedEventHandler PropertyChanged;
        public BoardViewModel(MyModel model)
        {
            this.simulatorModel = model;
            simulatorModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        public void NotifyPropertyChanged(string propName)
        {
            //paul's example, if it doesn't work try like eli's example
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public double VM_Indicated_heading_deg { 
            get
            {
                return simulatorModel.Indicated_heading_deg;
            }
        }
        public double VM_Gps_indicated_vertical_speed {
            get {
                return simulatorModel.Gps_indicated_vertical_speed;
            } 
        }
        public double VM_Gps_indicated_ground_speed_kt {
            get {
                return simulatorModel.Gps_indicated_ground_speed_kt;
            }
        }
        public double VM_Airspeed_indicator_indicated_speed_kt {
            get
            {
                return simulatorModel.Airspeed_indicator_indicated_speed_kt;
            }
        }
        public double VM_Gps_indicated_altitude_ft {
            get {
                return simulatorModel.Gps_indicated_altitude_ft;
            }
        }
        public double VM_Attitude_indicator_internal_roll_deg {
            get {
                return simulatorModel.Attitude_indicator_internal_roll_deg;
            }
        }
        public double VM_Attitude_indicator_internal_pitch_deg {
            get {
                return simulatorModel.Attitude_indicator_internal_pitch_deg;
            }
        }
        public double VM_Altimeter_indicated_altitude_ft {
            get {
                return simulatorModel.Altimeter_indicated_altitude_ft;
            }
        }
    }
}
