using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net;



namespace ex1_JennyAndYael
{
    public interface ISettingsModel : INotifyPropertyChanged
    {
        //This method used for saving the settings entered - Ip and port.
        void SaveSettings();
        string ServerIP { get; set; }
        string ServerPort { get; set; }
        //This method used for reset the settings.
        void ResetSettings();
    }
}
