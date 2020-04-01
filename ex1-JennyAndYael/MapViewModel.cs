﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Maps.MapControl.WPF;

namespace ex1_JennyAndYael
{
    public class MapViewModel : INotifyPropertyChanged
    {
        private MyModel simulatorModel;
        public Location VM_location;
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
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VM_Location"));
            VM_Location = new Location(VM_Latitude_deg, VM_Longitude_deg);
            
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
        public Location VM_Location
        {
            get
            {
                return new Location(VM_Latitude_deg, VM_Longitude_deg);
            }
            set
            {
                VM_location = value;
            }
        }
    }
}
