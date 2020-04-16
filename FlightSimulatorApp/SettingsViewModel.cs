using System.ComponentModel;
using System.Linq;
using System.Net;

namespace FlightSimulator
{
    class SettingsViewModel : INotifyPropertyChanged
    {
        private ISettingsModel model;
        private IPAddress ipAddress;
        private string errorMsg = null;
        public event PropertyChangedEventHandler PropertyChanged;

        //This method set the view model's model be the given model.
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
                if (IPAddress.TryParse(value, out ipAddress) && ipAddress.ToString().Equals(value))
                {
                    model.ServerIP = value;
                    NotifyPropertyChanged("ServerIP");
                    VmWrongDetails = null;
                }
                else
                {
                    VmWrongDetails = "Wrong IP address";
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
                    VmWrongDetails = "Wrong port";
                }
                else
                {
                    VmWrongDetails = null;
                    model.ServerPort = value;
                    NotifyPropertyChanged("ServerPort");
                }
            }
        }
        public string VmWrongDetails
        {
            get
            {
                return errorMsg;
            }
            set
            {
                errorMsg = value;
                NotifyPropertyChanged("VmWrongDetails");
            }
        }
        //This method updates the the poperty is changed.
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        //This method saves the settings - the default or the user input.
        public void SaveSettings()
        {
            model.SaveSettings();
        }
        //This method reset the settings to the default.
        public void ResetToDefaultSettings()
        {
            model.ResetSettings();
        }


    }
}
