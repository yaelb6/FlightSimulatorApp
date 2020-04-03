using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1_JennyAndYael
{
    class SettingsViewModel : INotifyPropertyChanged
    {
        private ISettingsModel model;
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
                model.ServerIP = value;
                NotifyPropertyChanged("ServerIP");
            }
        }
        public string ServerPort
        {
            get { return model.ServerPort; }
            set
            {
                model.ServerPort = value;
                NotifyPropertyChanged("ServerPort");
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
