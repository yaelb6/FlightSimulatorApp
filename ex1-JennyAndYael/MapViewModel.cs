using System;
using System.ComponentModel;
using Microsoft.Maps.MapControl.WPF;

namespace FlightSimulator
{
    public class MapViewModel : INotifyPropertyChanged
    {
        private MyModel simulatorModel;
        public Location vmLocation;
        public event PropertyChangedEventHandler PropertyChanged;
        //constructor
        public MapViewModel(MyModel model)
        {
            this.simulatorModel = model;
            simulatorModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("Vm" + e.PropertyName);
            };
        }
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VmLocation"));
            VmLocation = new Location(VmLatitude, VmLongitude);
        }
        public double VmLatitude
        {
            get
            {
                return simulatorModel.Latitude;
            }
        }
        public double VmLongitude
        {
            get
            {
                return simulatorModel.Longitude;
            }
        }
        public Location VmLocation
        {
            get
            {
                return new Location(VmLatitude, VmLongitude);
            }
            set
            {
                vmLocation = value;
            }
        }
    }
}
