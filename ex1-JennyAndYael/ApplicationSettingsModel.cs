using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace FlightSimulator
{
    //This is the window that the user can enter ip and port to login to the application.
    class ApplicationSettingsModel : ISettingsModel
    {

        public string ServerIP
        {
            get { return Properties.Settings.Default.ServerIPValue; }
            set
            {
                //If the ip changed, update it accordingly.
                Properties.Settings.Default.ServerIPValue = value;
            }
        }
        public string ServerPort
        {
            get { return Properties.Settings.Default.PortValue; }
            set
            {
                //If the port changed,update it accordingly.
                Properties.Settings.Default.PortValue = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SaveSettings()
        {
            //Save the ip and port.
            Properties.Settings.Default.Save();
        }
        public void ResetSettings()
        {
            //Reset the ip and port.
            Properties.Settings.Default.Reset();
        }
    }
}
