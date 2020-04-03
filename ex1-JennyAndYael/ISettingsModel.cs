using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;



namespace ex1_JennyAndYael
{
    public interface ISettingsModel : INotifyPropertyChanged
    {
        void SaveSettings();
        string ServerIP { get; set; }
        string ServerPort { get; set; }

        void ResetSettings();
    }
}
