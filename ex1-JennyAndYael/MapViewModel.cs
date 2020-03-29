using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ex1_JennyAndYael
{
    class MapViewModel : INotifyPropertyChanged
    {
        private MyModel simulatorModel;
        public event PropertyChangedEventHandler PropertyChanged;
        //constructor
        public MapViewModel(MyModel model)
        {
            this.simulatorModel = model;
            simulatorModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        public void NotifyPropertyChanged(string propName) {
            //paul's example, if it doesn't work try like eli's example
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public double VM_Latitude_deg
        {
            get
            {
                return simulatorModel.Latitude_deg;
            }
        }
        public double VM_Longitude_deg
        {
            get
            {
                return simulatorModel.Longitude_deg;
            }
        }
    }
}
