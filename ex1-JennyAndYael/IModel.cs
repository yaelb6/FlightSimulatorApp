using System.ComponentModel;

namespace FlightSimulator
{
    public interface IModel : INotifyPropertyChanged
    {
        //This method used for connection to the server.
        void Connect();
        //This method used for disconnection to the server.
        void Disconnect();
        //This method used for starting the communication with the server.
        void Start();

        // data table properties
        string Heading { set; get; }
        string VerticalSpeed { set; get; }
        string GroundSpeed { set; get; }
        string Airspeed { set; get; }
        string GpsAltitude { set; get; }
        string AttitudeRoll { set; get; }
        string AttitudePitch { set; get; }
        string AltimeterAltitude { set; get; }

        //map properties
        double Latitude { set; get; }
        double Longitude { set; get; }

        //map error property
        string ErrorMap { get; }
    }
}
