using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ex1_JennyAndYael
{
    public interface IModel : INotifyPropertyChanged
    {
        //This method used for connection to the server.
        void Connect();
        //This method used for disconnection to the server.
        void Disconnect();
        //This method used for starting the communication with the server.
        void Start();

        //These are the data table properties.
        string Indicated_heading_deg { set; get; }
        string Gps_indicated_vertical_speed { set; get; }
        string Gps_indicated_ground_speed_kt { set; get; }
        string Airspeed_indicator_indicated_speed_kt { set; get; }
        string Gps_indicated_altitude_ft { set; get; }
        string Attitude_indicator_internal_roll_deg { set; get; }
        string Attitude_indicator_internal_pitch_deg { set; get; }
        string Altimeter_indicated_altitude_ft { set; get; }

        //These are the map properties.
        double Latitude_deg { set; get; }
        double Longitude_deg { set; get; }

        //These are the map error property.
        string Error_map { get; }
    }
}
