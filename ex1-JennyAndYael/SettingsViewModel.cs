using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ex1_JennyAndYael
{
    class SettingsViewModel : INotifyPropertyChanged
    {
        private ISettingsModel model;
        private IPAddress iPAddress;
        private string error_msg = null;
        public event PropertyChangedEventHandler PropertyChanged;

        public SettingsViewModel(ISettingsModel model)
        {
            this.model = model;
            this.model.ServerIP = null;
            this.model.ServerPort = null;
        }
        public string ServerIP
        {
            get { return model.ServerIP; }
            set
            {
                if (IPAddress.TryParse(value, out iPAddress) && iPAddress.ToString().Equals(value))
                {
                    model.ServerIP = value;
                    NotifyPropertyChanged("ServerIP");
                    VM_Wrong_details = null;
                } else
                {
                    VM_Wrong_details = "Wrong IP address";
                }
            }
        }
        public string ServerPort
        {
            get { return model.ServerPort; }
            set
            {
                if (!value.All(char.IsDigit))
                {
                    VM_Wrong_details = "Wrong port";
                }
                else
                {
                    VM_Wrong_details = null;
                    model.ServerPort = value;
                    NotifyPropertyChanged("ServerPort");
                }
            }
        }
        public string VM_Wrong_details
        {
            get
            {
                return error_msg;
            } 
            set
            {
                error_msg = value;
                NotifyPropertyChanged("VM_Wrong_details");
            }
        }
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public void SaveSettings()
        {
            model.SaveSettings();
        }
        public void ResetToDefaultSettings()
        {

            model.ResetSettings();
        }


    }
}
