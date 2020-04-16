using System.ComponentModel;



namespace FlightSimulator
{
    public interface ISettingsModel : INotifyPropertyChanged
    {
        void SaveSettings();
        string ServerIP { get; set; }
        string ServerPort { get; set; }
        void ResetSettings();
    }
}
