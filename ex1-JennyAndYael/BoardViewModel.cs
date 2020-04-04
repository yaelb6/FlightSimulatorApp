using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ex1_JennyAndYael
{
    public class BoardViewModel : INotifyPropertyChanged
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
        public string VM_Indicated_heading_deg { 
            get
            {
                    return simulatorModel.Indicated_heading_deg;
            }
        }
        public string VM_Gps_indicated_vertical_speed {
            get {
                return simulatorModel.Gps_indicated_vertical_speed;
            } 
        }
        public string VM_Gps_indicated_ground_speed_kt {
            get {
                return simulatorModel.Gps_indicated_ground_speed_kt;
            }
        }
        public string VM_Airspeed_indicator_indicated_speed_kt {
            get
            {
                return simulatorModel.Airspeed_indicator_indicated_speed_kt;
            }
        }
        public string VM_Gps_indicated_altitude_ft {
            get {
                return simulatorModel.Gps_indicated_altitude_ft;
            }
        }
        public string VM_Attitude_indicator_internal_roll_deg {
            get {
                return simulatorModel.Attitude_indicator_internal_roll_deg;
            }
        }
        public string VM_Attitude_indicator_internal_pitch_deg {
            get {
                return simulatorModel.Attitude_indicator_internal_pitch_deg;
            }
        }
        public string VM_Altimeter_indicated_altitude_ft {
            get {
                return simulatorModel.Altimeter_indicated_altitude_ft;
            }
        }
        public string VM_Error_map
        {
            get
            {
                return simulatorModel.Error_map;
            }
        }
        public string VM_Error_dashboard
        {
            get
            {
                return simulatorModel.Error_dashboard;
            }
        }
        public string VM_Slow_server
        {
            get
            {
                return simulatorModel.Slow_server;
            }
        }
        public string VM_Disconnected_server
        {
            get
            {
                return simulatorModel.Disconnected_server;
            }
        }
    }
}
