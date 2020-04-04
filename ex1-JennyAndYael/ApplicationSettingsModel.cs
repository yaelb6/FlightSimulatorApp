using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ex1_JennyAndYael
{
    class ApplicationSettingsModel : ISettingsModel
    {

        public string ServerIP
        {
            get { return Properties.Settings.Default.ServerIPValue; }
            set {
                Properties.Settings.Default.ServerIPValue = value;
            }
        }
        public string ServerPort
        {
            get { return Properties.Settings.Default.PortValue; }
            set { Properties.Settings.Default.PortValue = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
        public void ResetSettings()
        {
            Properties.Settings.Default.Reset();
        }
    }
}
