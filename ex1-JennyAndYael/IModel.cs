using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ex1_JennyAndYael
{
    interface IModel : INotifyPropertyChanged
    {
        // connection to the robot
        void connect(string ip, int port);
        void disconnect();
        void start();

        // sensors properties
        double indicated_heading_deg { set; get; }
        double gps_indicated_vertical_speed { set; get; }
        double gps_indicated_ground_speed_kt { set; get; }
        double airspeed_indicator_indicated_speed_kt { set; get; }
        double gps_indicated_altitude_ft { set; get; }
        double attitude_indicator_internal_roll_deg { set; get; }
        double attitude_indicator_internal_pitch_deg { set; get; }
        double altimeter_indicated_altitude_ft { set; get; }
    }
}
