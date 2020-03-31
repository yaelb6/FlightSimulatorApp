using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ex1_JennyAndYael
{
    public class MyModel : IModel
    {
        //INotifyPropertyChanged implementation:
        public event PropertyChangedEventHandler PropertyChanged;

        MyClient telnetClient;
        volatile Boolean stop;
        // 8 fields for data table
        private double indicated_heading_deg;
        private double gps_indicated_vertical_speed;
        private double gps_indicated_ground_speed_kt;
        private double airspeed_indicator_indicated_speed_kt;
        private double gps_indicated_altitude_ft;
        private double attitude_indicator_internal_roll_deg;
        private double attitude_indicator_internal_pitch_deg;
        private double altimeter_indicated_altitude_ft;

        //4 fields for joystick
        private double rudder;
        private double throttle;
        private double aileron;
        private double elevator;

        //2 fields for map
        private double latitude;
        private double longitude;

        public void updateRudderAndElevator (double rudder, double elevator)
        {
            this.rudder = rudder;
            this.elevator = elevator;
        }
        public void updateAileron (double aileron)
        {
            this.aileron = aileron;
        }
        public void updateThrottle (double throttle)
        {
            this.throttle = throttle;
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public double Indicated_heading_deg
        {
            get
            {
                return indicated_heading_deg;
            }
            set
            {
                indicated_heading_deg = value;
                NotifyPropertyChanged("Indicated_heading_deg");
            }

        }
        public double Gps_indicated_vertical_speed
        {
            get
            {
                return gps_indicated_vertical_speed;
            }
            set
            {
                gps_indicated_vertical_speed = value;
                NotifyPropertyChanged("Gps_indicated_vertical_speed");
            }
        }
        public double Gps_indicated_ground_speed_kt
        {
            get
            {
                return gps_indicated_ground_speed_kt;
            }
            set
            {
                gps_indicated_ground_speed_kt = value;
                NotifyPropertyChanged("Gps_indicated_vertical_speed");
            }
        }
        public double Airspeed_indicator_indicated_speed_kt
        {
            get
            {
                return airspeed_indicator_indicated_speed_kt;
            }
            set
            {
                airspeed_indicator_indicated_speed_kt = value;
                NotifyPropertyChanged("Airspeed_indicator_indicated_speed_kt");
            }
        }
        public double Gps_indicated_altitude_ft
        {
            get
            {
                return gps_indicated_altitude_ft;
            }
            set
            {
                gps_indicated_altitude_ft = value;
                NotifyPropertyChanged("Gps_indicated_altitude_ft");
            }
        }
        public double Attitude_indicator_internal_roll_deg
        {
            get
            {
                return attitude_indicator_internal_roll_deg;
            }
            set
            {
                attitude_indicator_internal_roll_deg = value;
                NotifyPropertyChanged("Attitude_indicator_internal_roll_deg");
            }
        }
        public double Attitude_indicator_internal_pitch_deg
        {
            get
            {
                return attitude_indicator_internal_pitch_deg;
            }
            set
            {
                attitude_indicator_internal_pitch_deg = value;
                NotifyPropertyChanged("Attitude_indicator_internal_pitch_deg");
            }
        }
        public double Altimeter_indicated_altitude_ft
        {
            get
            {
                return altimeter_indicated_altitude_ft;
            }
            set
            {
                altimeter_indicated_altitude_ft = value;
                NotifyPropertyChanged("Altimeter_indicated_altitude_ft");
            }
        }
        public double Latitude_deg
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
                NotifyPropertyChanged("Latitude_deg");
            }
        }
        public double Longitude_deg
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
                NotifyPropertyChanged("Longitude_deg");
            }
        }

        public MyModel(MyClient telnetClient)
        {
            this.telnetClient = telnetClient;
            stop = false;
        }

        public void connect()
        {
            telnetClient.connect();
        }
        public void disconnect()
        {
            stop = true;
            telnetClient.disconnect();
        }
        public void start()
        {
            new Thread(delegate ()
            {
                connect();
                while (!stop)
                {
                    string message;
                    // get 8 values for data table
                    message = "get /instrumentation/heading-indicator/indicated-heading-deg\n";
                    if (telnetClient.get(message).Equals("ERR\n"))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        Indicated_heading_deg = Double.Parse(telnetClient.get(message));
                    }

                    message = "get  /instrumentation/gps/indicated-vertical-speed\n";
                    if (telnetClient.get(message).Equals("ERR\n"))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        Gps_indicated_vertical_speed = Double.Parse(telnetClient.get(message));
                    }

                    message = "get /instrumentation/gps/indicated-ground-speed-kt\n";
                    if (telnetClient.get(message).Equals("ERR\n"))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        Gps_indicated_ground_speed_kt = Double.Parse(telnetClient.get(message));
                    }

                    message = "get /instrumentation/airspeed-indicator/indicated-speed-kt\n";
                    if (telnetClient.get(message).Equals("ERR\n"))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        Airspeed_indicator_indicated_speed_kt = Double.Parse(telnetClient.get(message));
                    }

                    message = "get /instrumentation/gps/indicated-altitude-ft\n";
                    if (telnetClient.get(message).Equals("ERR\n"))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        Gps_indicated_altitude_ft = Double.Parse(telnetClient.get(message));
                    }

                    message = "get /instrumentation/attitude-indicator/internal-roll-deg\n";
                    if (telnetClient.get(message).Equals("ERR\n"))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        Attitude_indicator_internal_roll_deg = Double.Parse(telnetClient.get(message));
                    }

                    message = "get /instrumentation/attitude-indicator/internal-pitch-deg\n";
                    if (telnetClient.get(message).Equals("ERR\n"))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        Attitude_indicator_internal_pitch_deg = Double.Parse(telnetClient.get(message));
                    }

                    message = "get /instrumentation/altimeter/indicated-altitude-ft\n";
                    if (telnetClient.get(message).Equals("ERR\n"))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        Altimeter_indicated_altitude_ft = Double.Parse(telnetClient.get(message));
                    }

                    //set 4 properties from joystick
                    message = "set /controls/flight/rudder" + this.rudder + "\n";
                    telnetClient.set(message);
                    message = "set /controls/flight/elevator" + this.throttle + "\n";
                    telnetClient.set(message);
                    message = "set /controls/flight/aileron" + this.aileron + "\n";
                    telnetClient.set(message);
                    message = "set /controls/engines/engine/throttle" + this.elevator + "\n";
                    telnetClient.set(message);

                    //get 2 properties for map
                    message = "get /position/latitude-deg\n";
                    if (telnetClient.get(message).Equals("ERR\n"))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        Latitude_deg = Double.Parse(telnetClient.get(message));
                    }

                    message = "get /position/longitude-deg\n";
                    if (telnetClient.get(message).Equals("ERR\n"))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        Latitude_deg = Double.Parse(telnetClient.get(message));
                    }

                    Console.WriteLine(indicated_heading_deg);
                    Console.WriteLine(gps_indicated_vertical_speed);
                    Console.WriteLine(gps_indicated_ground_speed_kt);
                    Console.WriteLine(airspeed_indicator_indicated_speed_kt);
                    Console.WriteLine(gps_indicated_altitude_ft);
                    Console.WriteLine(attitude_indicator_internal_roll_deg);
                    Console.WriteLine(attitude_indicator_internal_pitch_deg);
                    Console.WriteLine(altimeter_indicated_altitude_ft);

                    Console.WriteLine(rudder);
                    Console.WriteLine(throttle);
                    Console.WriteLine(aileron);
                    Console.WriteLine(elevator);

                    Console.WriteLine(Latitude_deg);
                    Console.WriteLine(Longitude_deg);

                    // the same for the other sensors properties
                    Thread.Sleep(250);// read the data in 4Hz
                }
            }).Start();
        }

    }
}
