using System.ComponentModel;



namespace FlightSimulator
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
