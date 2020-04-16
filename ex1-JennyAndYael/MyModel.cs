using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace ex1_JennyAndYael
{
    public class MyModel : IModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        MyClient telnetClient;
        volatile Boolean stop;
        // 8 fields for data table.
        private string indicated_heading_deg;
        private string gps_indicated_vertical_speed;
        private string gps_indicated_ground_speed_kt;
        private string airspeed_indicator_indicated_speed_kt;
        private string gps_indicated_altitude_ft;
        private string attitude_indicator_internal_roll_deg;
        private string attitude_indicator_internal_pitch_deg;
        private string altimeter_indicated_altitude_ft;

        //4 fields for joystick.
        private double rudder;
        private double throttle;
        private double aileron;
        private double elevator;

        //2 fields for map.
        private double latitude;
        private double longitude;

        private string error_map = null;
        private string slow_server = null;
        private string server_disconnected = null;
        private string error_dashboard = null;

        //This method change the boolean value.
        public void setStop(bool val)
        {
            this.stop = val;
        }
        //This method updates the rudder and elevator values.
        public void updateRudderAndElevator (double rudder, double elevator)
        {
            this.rudder = rudder;
            this.elevator = elevator;
        }
        //This method updates the aileron values.
        public void updateAileron (double aileron)
        {
            this.aileron = aileron;
        }
        //This method updates the throttle values.
        public void updateThrottle (double throttle)
        {
            this.throttle = throttle;
        }
        //This method updates that the property changed.
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public string Indicated_heading_deg
        {
            get
            {
                return indicated_heading_deg;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    Error_dashboard = "Error in dashboard values";
                } else
                {
                    Error_dashboard = null;
                }
                indicated_heading_deg = value;
                NotifyPropertyChanged("Indicated_heading_deg");
            }

        }
        public string Gps_indicated_vertical_speed
        {
            get
            {
                return gps_indicated_vertical_speed;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    Error_dashboard = "Error in dashboard values";
                }
                else
                {
                    Error_dashboard = null;
                }
                gps_indicated_vertical_speed = value;
                NotifyPropertyChanged("Gps_indicated_vertical_speed");
            }
        }
        public string Gps_indicated_ground_speed_kt
        {
            get
            {
                return gps_indicated_ground_speed_kt;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    Error_dashboard = "Error in dashboard values";
                }
                else
                {
                    Error_dashboard = null;
                }
                gps_indicated_ground_speed_kt = value;
                NotifyPropertyChanged("Gps_indicated_ground_speed_kt");
            }
        }
        public string Airspeed_indicator_indicated_speed_kt
        {
            get
            {
                return airspeed_indicator_indicated_speed_kt;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    Error_dashboard = "Error in dashboard values";
                }
                else
                {
                    Error_dashboard = null;
                }
                airspeed_indicator_indicated_speed_kt = value;
                NotifyPropertyChanged("Airspeed_indicator_indicated_speed_kt");
            }
        }
        public string Gps_indicated_altitude_ft
        {
            get
            {
                return gps_indicated_altitude_ft;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    Error_dashboard = "Error in dashboard values";
                }
                else
                {
                    Error_dashboard = null;
                }
                gps_indicated_altitude_ft = value;
                NotifyPropertyChanged("Gps_indicated_altitude_ft");
            }
        }
        public string Attitude_indicator_internal_roll_deg
        {
            get
            {
                return attitude_indicator_internal_roll_deg;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    Error_dashboard = "Error in dashboard values";
                }
                else
                {
                    Error_dashboard = null;
                }
                attitude_indicator_internal_roll_deg = value;
                NotifyPropertyChanged("Attitude_indicator_internal_roll_deg");
            }
        }
        public string Attitude_indicator_internal_pitch_deg
        {
            get
            {
                return attitude_indicator_internal_pitch_deg;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    Error_dashboard = "Error in dashboard values";
                }
                else
                {
                    Error_dashboard = null;
                }
                attitude_indicator_internal_pitch_deg = value;
                NotifyPropertyChanged("Attitude_indicator_internal_pitch_deg");
            }
        }
        public string Altimeter_indicated_altitude_ft
        {
            get
            {
                return altimeter_indicated_altitude_ft;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    Error_dashboard = "Error in dashboard values";
                }
                else
                {
                    Error_dashboard = null;
                }
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
                if ((value > 85) || (value < -85))
                {
                    if (value > 85)
                    {
                        value = 85;
                    } else
                    {
                        value = -85;
                        
                    }
                    Error_map = "Error : Invalid map coordinates";
                } 
                else if ((longitude < 180) && (longitude > -180)) {
                    Error_map = null;
                }
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
                if ((value > 180) || (value < -180))
                {
                    if (value > 180)
                    {
                        value = 180;
                    }
                    else
                    {
                        value = -180;
                    }
                    Error_map = "Error : Invalid map coordinates";
                }
                else if ((latitude < 85) && (latitude > -85))
                {
                    Error_map = null;
                }
                longitude = value;
                NotifyPropertyChanged("Longitude_deg");
            }
        }
        public string Error_map
        {
            get
            {
                return error_map;
            }
            set
            {
                error_map = value;
                NotifyPropertyChanged("Error_map");
            }
        }
        public string Error_dashboard
        {
            get
            {
                return error_dashboard;
            }
            set
            {
                error_dashboard = value;
                NotifyPropertyChanged("Error_dashboard");
            }
        }
        public string Slow_server
        {
            get
            {
                return slow_server;
            }
            set
            {
                slow_server = value;
                NotifyPropertyChanged("Slow_server");
            }
        }
        public string Disconnected_server
        {
            get
            {
                return server_disconnected;
            }
            set
            {
                server_disconnected = value;
                Slow_server = null;
                NotifyPropertyChanged("Disconnected_server");
            }
        }
        public MyModel(MyClient telnetClient)
        {
            this.telnetClient = telnetClient;
            stop = false;
        }

        public void Connect()
        {
            telnetClient.Connect();
        }
        public void Disconnect()
        {
            stop = true;
            telnetClient.Disconnect();
        }
        //This method is a loop of communication with the server.
        //Until the boolean flag -stop, changes, it send and recieve data from the server.
        public void Start()
        {
            new Thread(delegate ()
            {
                Connect();
                while (!stop)
                {
                    string message;
                    string responseData;
                    // Get 8 values for data table.
                    message = "get /instrumentation/heading-indicator/indicated-heading-deg\n";
                    try
                    {
                        if (telnetClient.get(message).Equals("ERR\n"))
                        {
                            Indicated_heading_deg = "ERR";
                        } 
                        else if (telnetClient.get(message).Equals("disconnected")) {
                            Disconnected_server = "Error: Server was disconnected";
                        }
                        else
                        {
                            Indicated_heading_deg = telnetClient.get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException e)
                    {
                        Slow_server = "Error: Server is too slow";
                    }
                    message = "get  /instrumentation/gps/indicated-vertical-speed\n";
                    try
                    {
                        if (telnetClient.get(message).Equals("ERR\n"))
                        {
                            Gps_indicated_vertical_speed = "ERR";
                        }
                        else if (telnetClient.get(message).Equals("disconnected"))
                        {
                            Disconnected_server = "Error: Server was disconnected";
                        }
                        else
                        {
                            Gps_indicated_vertical_speed = telnetClient.get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException e)
                    {
                        Slow_server = "Error: Server is too slow";
                    }

                    message = "get /instrumentation/gps/indicated-ground-speed-kt\n";
                    try
                    {
                        if (telnetClient.get(message).Equals("ERR\n"))
                        {
                            Gps_indicated_ground_speed_kt = "ERR";
                        }
                        else if (telnetClient.get(message).Equals("disconnected"))
                        {
                            Disconnected_server = "Error: Server was disconnected";
                        }
                        else
                        {
                            Gps_indicated_ground_speed_kt = telnetClient.get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException e)
                    {
                        Slow_server = "Error: Server is too slow";
                    }

                    message = "get /instrumentation/airspeed-indicator/indicated-speed-kt\n";
                    try
                    {
                        if (telnetClient.get(message).Equals("ERR\n"))
                        {
                            Airspeed_indicator_indicated_speed_kt = "ERR";
                        }
                        else if (telnetClient.get(message).Equals("disconnected"))
                        {
                            Disconnected_server = "Error: Server was disconnected";
                        }
                        else
                        {
                            Airspeed_indicator_indicated_speed_kt = telnetClient.get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException e)
                    {
                        Slow_server = "Error: Server is too slow";
                    }

                    message = "get /instrumentation/gps/indicated-altitude-ft\n";
                    try
                    {
                        if (telnetClient.get(message).Equals("ERR\n"))
                        {
                            Gps_indicated_altitude_ft = "ERR";
                        }
                        else if (telnetClient.get(message).Equals("disconnected"))
                        {
                            Disconnected_server = "Error: Server was disconnected";
                        }
                        else
                        {
                            Gps_indicated_altitude_ft = telnetClient.get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException e)
                    {
                        Slow_server = "Error: Server is too slow";
                    }

                    message = "get /instrumentation/attitude-indicator/internal-roll-deg\n";
                    try
                    {
                        if (telnetClient.get(message).Equals("ERR\n"))
                        {
                            Attitude_indicator_internal_roll_deg = "ERR";
                        }
                        else if (telnetClient.get(message).Equals("disconnected"))
                        {
                            Disconnected_server = "Error: Server was disconnected";
                        }
                        else
                        {
                            Attitude_indicator_internal_roll_deg = telnetClient.get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException e)
                    {
                        Slow_server = "Error: Server is too slow";
                    }

                    message = "get /instrumentation/attitude-indicator/internal-pitch-deg\n";
                    try
                    {
                        if (telnetClient.get(message).Equals("ERR\n"))
                        {
                            Attitude_indicator_internal_pitch_deg = "ERR";
                        }
                        else if (telnetClient.get(message).Equals("disconnected"))
                        {
                            Disconnected_server = "Error: Server was disconnected";
                        }
                        else
                        {
                            Attitude_indicator_internal_pitch_deg = telnetClient.get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException e)
                    {
                        Slow_server = "Error: Server is too slow";
                    }

                    message = "get /instrumentation/altimeter/indicated-altitude-ft\n";
                    try
                    {
                        if (telnetClient.get(message).Equals("ERR\n"))
                        {
                            Altimeter_indicated_altitude_ft = "ERR";
                        }
                        else if (telnetClient.get(message).Equals("disconnected"))
                        {
                            Disconnected_server = "Error: Server was disconnected";
                        }
                        else
                        {
                            Altimeter_indicated_altitude_ft = telnetClient.get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException e)
                    {
                        Slow_server = "Error: Server is too slow";
                    }

                    //Set 4 properties from joystick.
                    message = "set /controls/flight/rudder " + this.rudder + "\n";
                    try
                    {
                        responseData = telnetClient.Set(message);
                        if (responseData.Equals("disconnected"))
                        {
                            Disconnected_server = "Error: Server was disconnected";
                        }
                    }
                    catch (IOException e)
                    {
                        Slow_server = "Error: Server is too slow";
                    }
                    message = "set /controls/flight/throttle " + this.throttle + "\n";
                    try
                    {
                        responseData = telnetClient.Set(message);
                        if (responseData.Equals("disconnected"))
                        {
                            Disconnected_server = "Error: Server was disconnected";
                        }
                    } catch (IOException e)
                    {
                        Slow_server = "Error: Server is too slow";
                    }
                    message = "set /controls/flight/aileron " + this.aileron + "\n";
                    try
                    {
                        responseData = telnetClient.Set(message);
                        if (responseData.Equals("disconnected"))
                        {
                            Disconnected_server = "Error: Server was disconnected";
                        }
                    }
                    catch (IOException e)
                    {
                        Slow_server = "Error: Server is too slow";
                    }
                    message = "set /controls/flight/elevator " + this.elevator + "\n";
                    try
                    {
                        responseData = telnetClient.Set(message);
                        if (responseData.Equals("disconnected"))
                        {
                            Disconnected_server = "Error: Server was disconnected";
                        }
                    }
                    catch (Exception e)
                    {
                        Slow_server = "Error: Server is too slow";
                    }

                    //Get 2 properties for map.
                    message = "get /position/latitude-deg\n";
                    try
                    {
                        if (telnetClient.get(message).Equals("ERR\n"))
                        {
                            Error_map = "Error : ERR in map coordinates";
                        }
                        else if (telnetClient.get(message).Equals("disconnected"))
                        {
                            Disconnected_server = "Error: Server was disconnected";
                        }
                        else
                        {
                            if (double.TryParse(telnetClient.get(message), out latitude))
                            {
                                Latitude_deg = Double.Parse(telnetClient.get(message));
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    catch (IOException e)
                    {
                        Slow_server = "Error: Server is too slow";
                    }

                    message = "get /position/longitude-deg\n";
                    try
                    {
                        if (telnetClient.get(message).Equals("ERR\n"))
                        {
                            Error_map = "Error : ERR in map coordinates";
                        }
                        else if (telnetClient.get(message).Equals("disconnected"))
                        {
                            Disconnected_server = "Error: Server was disconnected";
                        }
                        else
                        {
                            if (double.TryParse(telnetClient.get(message), out longitude))
                            {
                                Longitude_deg = Double.Parse(telnetClient.get(message));
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    catch (IOException e)
                    {
                        Slow_server = "Error: Server is too slow";
                    }


                    // The same for the other sensors properties.
                    // Read the data in 4Hz.
                    Thread.Sleep(250);
                }
            }).Start();
        }

    }
}
