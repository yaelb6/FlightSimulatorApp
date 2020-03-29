using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ex1_JennyAndYael
{
    class MyModel : IModel
    {
        //INotifyPropertyChanged implementation:
        public event PropertyChangedEventHandler PropertyChanged;

        MyClient telnetClient;
        volatile Boolean stop;

        public double indicated_heading_deg { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double gps_indicated_vertical_speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double gps_indicated_ground_speed_kt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double airspeed_indicator_indicated_speed_kt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double gps_indicated_altitude_ft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double attitude_indicator_internal_roll_deg { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double attitude_indicator_internal_pitch_deg { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double altimeter_indicated_altitude_ft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MyModel(MyClient telnetClient)
        {
            this.telnetClient = telnetClient;
            stop = false;
        }
        public void connect(string ip, int port)
        {
            telnetClient.connect(ip, port);
        }
        public void disconnect()
        {
            stop = true;
            telnetClient.disconnect();
        }

        public void start()
        {
            new Thread(delegate () {
                while (!stop)
                {
                    telnetClient.get("get left sonar");

                    LeftSonar = Double.Parse(telnetClient.set());
                    // the same for the other sensors properties
                    Thread.Sleep(250);// read the data in 4Hz
                }
            }).Start();
        }



    }
}
