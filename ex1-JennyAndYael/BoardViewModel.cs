using System;
using System.ComponentModel;

namespace FlightSimulator
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
                NotifyPropertyChanged("Vm" + e.PropertyName);
            };
        }
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public string VmHeading
        {
            get
            {
                return simulatorModel.Heading;
            }
        }
        public string VmVerticalSpeed
        {
            get
            {
                return simulatorModel.VerticalSpeed;
            }
        }
        public string VmGroundSpeed
        {
            get
            {
                return simulatorModel.GroundSpeed;
            }
        }
        public string VmAirspeed
        {
            get
            {
                return simulatorModel.Airspeed;
            }
        }
        public string VmGpsAltitude
        {
            get
            {
                return simulatorModel.GpsAltitude;
            }
        }
        public string VmAttitudeRoll
        {
            get
            {
                return simulatorModel.AttitudeRoll;
            }
        }
        public string VmAttitudePitch
        {
            get
            {
                return simulatorModel.AttitudePitch;
            }
        }
        public string VmAltimeterAltitude
        {
            get
            {
                return simulatorModel.AltimeterAltitude;
            }
        }
        public string VmErrorMap
        {
            get
            {
                return simulatorModel.ErrorMap;
            }
        }
        public string VmErrorDashboard
        {
            get
            {
                return simulatorModel.ErrorDashboard;
            }
        }
        public string VmSlowServer
        {
            get
            {
                return simulatorModel.SlowServer;
            }
        }
        public string VmDisconnectedServer
        {
            get
            {
                return simulatorModel.DisconnectedServer;
            }
        }
    }
}
