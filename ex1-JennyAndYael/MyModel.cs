using System;
using System.ComponentModel;
using System.Threading;
using System.IO;

namespace FlightSimulator
{
    public class MyModel : IModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        MyClient telnetClient;
        volatile Boolean stop;
        // 8 fields for data table
        private string heading;
        private string verticalSpeed;
        private string groundSpeed;
        private string airspeed;
        private string gpsAltitude;
        private string attitudeRoll;
        private string attitudePitch;
        private string altimeterAltitude;

        //4 fields for joystick.
        private double rudder;
        private double throttle;
        private double aileron;
        private double elevator;

        //2 fields for map.
        private double latitude;
        private double longitude;

        private string errorMap = null;
        private string slowServer = null;
        private string serverDisconnected = null;
        private string errorDashboard = null;

        //This method change the boolean value
        public void SetStop(bool val)
        {
            this.stop = val;
        }
        //This method updates the rudder and elevator values.
        public void UpdateRudderAndElevator(double rudder, double elevator)
        {
            this.rudder = rudder;
            this.elevator = elevator;
        }
        //This method updates the aileron values.
        public void UpdateAileron(double aileron)
        {
            this.aileron = aileron;
        }
        //This method updates the throttle values.
        public void UpdateThrottle(double throttle)
        {
            this.throttle = throttle;
        }
        //This method updates that the property changed.
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public string Heading
        {
            get
            {
                return heading;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    ErrorDashboard = "Error in dashboard values";
                }
                else
                {
                    ErrorDashboard = null;
                }
                heading = value;
                NotifyPropertyChanged("Heading");
            }

        }
        public string VerticalSpeed
        {
            get
            {
                return verticalSpeed;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    ErrorDashboard = "Error in dashboard values";
                }
                else
                {
                    ErrorDashboard = null;
                }
                verticalSpeed = value;
                NotifyPropertyChanged("VerticalSpeed");
            }
        }
        public string GroundSpeed
        {
            get
            {
                return groundSpeed;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    ErrorDashboard = "Error in dashboard values";
                }
                else
                {
                    ErrorDashboard = null;
                }
                groundSpeed = value;
                NotifyPropertyChanged("GroundSpeed");
            }
        }
        public string Airspeed
        {
            get
            {
                return airspeed;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    ErrorDashboard = "Error in dashboard values";
                }
                else
                {
                    ErrorDashboard = null;
                }
                airspeed = value;
                NotifyPropertyChanged("Airspeed");
            }
        }
        public string GpsAltitude
        {
            get
            {
                return gpsAltitude;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    ErrorDashboard = "Error in dashboard values";
                }
                else
                {
                    ErrorDashboard = null;
                }
                gpsAltitude = value;
                NotifyPropertyChanged("GpsAltitude");
            }
        }
        public string AttitudeRoll
        {
            get
            {
                return attitudeRoll;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    ErrorDashboard = "Error in dashboard values";
                }
                else
                {
                    ErrorDashboard = null;
                }
                attitudeRoll = value;
                NotifyPropertyChanged("AttitudeRoll");
            }
        }
        public string AttitudePitch
        {
            get
            {
                return attitudePitch;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    ErrorDashboard = "Error in dashboard values";
                }
                else
                {
                    ErrorDashboard = null;
                }
                attitudePitch = value;
                NotifyPropertyChanged("AttitudePitch");
            }
        }
        public string AltimeterAltitude
        {
            get
            {
                return altimeterAltitude;
            }
            set
            {
                if (value.Equals("ERR"))
                {
                    ErrorDashboard = "Error in dashboard values";
                }
                else
                {
                    ErrorDashboard = null;
                }
                altimeterAltitude = value;
                NotifyPropertyChanged("AltimeterAltitude");
            }
        }
        public double Latitude
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
                    }
                    else
                    {
                        value = -85;

                    }
                    ErrorMap = "Error : Invalid map coordinates";
                }
                else if ((longitude < 180) && (longitude > -180))
                {
                    ErrorMap = null;
                }
                latitude = value;
                NotifyPropertyChanged("Latitude");
            }
        }
        public double Longitude
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
                    ErrorMap = "Error : Invalid map coordinates";
                }
                else if ((latitude < 85) && (latitude > -85))
                {
                    ErrorMap = null;
                }
                longitude = value;
                NotifyPropertyChanged("Longitude");
            }
        }
        public string ErrorMap
        {
            get
            {
                return errorMap;
            }
            set
            {
                errorMap = value;
                NotifyPropertyChanged("ErrorMap");
            }
        }
        public string ErrorDashboard
        {
            get
            {
                return errorDashboard;
            }
            set
            {
                errorDashboard = value;
                NotifyPropertyChanged("ErrorDashboard");
            }
        }
        public string SlowServer
        {
            get
            {
                return slowServer;
            }
            set
            {
                slowServer = value;
                NotifyPropertyChanged("SlowServer");
            }
        }
        public string DisconnectedServer
        {
            get
            {
                return serverDisconnected;
            }
            set
            {
                serverDisconnected = value;
                SlowServer = null;
                NotifyPropertyChanged("DisconnectedServer");
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
                        if (telnetClient.Get(message).Equals("ERR\n"))
                        {
                            Heading = "ERR";
                        }
                        else if (telnetClient.Get(message).Equals("disconnected"))
                        {
                            DisconnectedServer = "Error: Server was disconnected";
                        }
                        else
                        {
                            Heading = telnetClient.Get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException)
                    {
                        SlowServer = "Error: Server is too slow";
                    }
                    message = "get /instrumentation/gps/indicated-vertical-speed\n";
                    try
                    {
                        if (telnetClient.Get(message).Equals("ERR\n"))
                        {
                            VerticalSpeed = "ERR";
                        }
                        else if (telnetClient.Get(message).Equals("disconnected"))
                        {
                            DisconnectedServer = "Error: Server was disconnected";
                        }
                        else
                        {
                            VerticalSpeed = telnetClient.Get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException)
                    {
                        SlowServer = "Error: Server is too slow";
                    }

                    message = "get /instrumentation/gps/indicated-ground-speed-kt\n";
                    try
                    {
                        if (telnetClient.Get(message).Equals("ERR\n"))
                        {
                            GroundSpeed = "ERR";
                        }
                        else if (telnetClient.Get(message).Equals("disconnected"))
                        {
                            DisconnectedServer = "Error: Server was disconnected";
                        }
                        else
                        {
                            GroundSpeed = telnetClient.Get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException)
                    {
                        SlowServer = "Error: Server is too slow";
                    }

                    message = "get /instrumentation/airspeed-indicator/indicated-speed-kt\n";
                    try
                    {
                        if (telnetClient.Get(message).Equals("ERR\n"))
                        {
                            Airspeed = "ERR";
                        }
                        else if (telnetClient.Get(message).Equals("disconnected"))
                        {
                            DisconnectedServer = "Error: Server was disconnected";
                        }
                        else
                        {
                            Airspeed = telnetClient.Get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException)
                    {
                        SlowServer = "Error: Server is too slow";
                    }

                    message = "get /instrumentation/gps/indicated-altitude-ft\n";
                    try
                    {
                        if (telnetClient.Get(message).Equals("ERR\n"))
                        {
                            GpsAltitude = "ERR";
                        }
                        else if (telnetClient.Get(message).Equals("disconnected"))
                        {
                            DisconnectedServer = "Error: Server was disconnected";
                        }
                        else
                        {
                            GpsAltitude = telnetClient.Get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException)
                    {
                        SlowServer = "Error: Server is too slow";
                    }

                    message = "get /instrumentation/attitude-indicator/internal-roll-deg\n";
                    try
                    {
                        if (telnetClient.Get(message).Equals("ERR\n"))
                        {
                            AttitudeRoll = "ERR";
                        }
                        else if (telnetClient.Get(message).Equals("disconnected"))
                        {
                            DisconnectedServer = "Error: Server was disconnected";
                        }
                        else
                        {
                            AttitudeRoll = telnetClient.Get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException)
                    {
                        SlowServer = "Error: Server is too slow";
                    }

                    message = "get /instrumentation/attitude-indicator/internal-pitch-deg\n";
                    try
                    {
                        if (telnetClient.Get(message).Equals("ERR\n"))
                        {
                            AttitudePitch = "ERR";
                        }
                        else if (telnetClient.Get(message).Equals("disconnected"))
                        {
                            DisconnectedServer = "Error: Server was disconnected";
                        }
                        else
                        {
                            AttitudePitch = telnetClient.Get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException)
                    {
                        SlowServer = "Error: Server is too slow";
                    }

                    message = "get /instrumentation/altimeter/indicated-altitude-ft\n";
                    try
                    {
                        if (telnetClient.Get(message).Equals("ERR\n"))
                        {
                            AltimeterAltitude = "ERR";
                        }
                        else if (telnetClient.Get(message).Equals("disconnected"))
                        {
                            DisconnectedServer = "Error: Server was disconnected";
                        }
                        else
                        {
                            AltimeterAltitude = telnetClient.Get(message).Substring(0, 5);
                        }
                    }
                    catch (IOException)
                    {
                        SlowServer = "Error: Server is too slow";
                    }

                    //Set 4 properties from joystick.
                    message = "set /controls/flight/rudder " + this.rudder + "\n";
                    try
                    {
                        responseData = telnetClient.Set(message);
                        if (responseData.Equals("disconnected"))
                        {
                            DisconnectedServer = "Error: Server was disconnected";
                        }
                    }
                    catch (IOException)
                    {
                        SlowServer = "Error: Server is too slow";
                    }
                    message = "set /controls/flight/throttle " + this.throttle + "\n";
                    try
                    {
                        responseData = telnetClient.Set(message);
                        if (responseData.Equals("disconnected"))
                        {
                            DisconnectedServer = "Error: Server was disconnected";
                        }
                    }
                    catch (IOException)
                    {
                        SlowServer = "Error: Server is too slow";
                    }
                    message = "set /controls/flight/aileron " + this.aileron + "\n";
                    try
                    {
                        responseData = telnetClient.Set(message);
                        if (responseData.Equals("disconnected"))
                        {
                            DisconnectedServer = "Error: Server was disconnected";
                        }
                    }
                    catch (IOException)
                    {
                        SlowServer = "Error: Server is too slow";
                    }
                    message = "set /controls/flight/elevator " + this.elevator + "\n";
                    try
                    {
                        responseData = telnetClient.Set(message);
                        if (responseData.Equals("disconnected"))
                        {
                            DisconnectedServer = "Error: Server was disconnected";
                        }
                    }
                    catch (Exception)
                    {
                        SlowServer = "Error: Server is too slow";
                    }

                    //Get 2 properties for map.
                    message = "get /position/latitude-deg\n";
                    try
                    {
                        if (telnetClient.Get(message).Equals("ERR\n"))
                        {
                            ErrorMap = "Error : ERR in map coordinates";
                        }
                        else if (telnetClient.Get(message).Equals("disconnected"))
                        {
                            DisconnectedServer = "Error: Server was disconnected";
                        }
                        else
                        {
                            if (double.TryParse(telnetClient.Get(message), out latitude))
                            {
                                Latitude = Double.Parse(telnetClient.Get(message));
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    catch (IOException)
                    {
                        SlowServer = "Error: Server is too slow";
                    }
                    message = "get /position/longitude-deg\n";
                    try
                    {
                        if (telnetClient.Get(message).Equals("ERR\n"))
                        {
                            ErrorMap = "Error : ERR in map coordinates";
                        }
                        else if (telnetClient.Get(message).Equals("disconnected"))
                        {
                            DisconnectedServer = "Error: Server was disconnected";
                        }
                        else
                        {
                            if (double.TryParse(telnetClient.Get(message), out longitude))
                            {
                                Longitude = Double.Parse(telnetClient.Get(message));
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    catch (IOException)
                    {
                        SlowServer = "Error: Server is too slow";
                    }
                    // The same for the other sensors properties.
                    // Read the data in 4Hz.
                    Thread.Sleep(250);
                }
            }).Start();
        }

    }
}
