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
                if ((value > 84.5) || (value < -84.5))
                {
                    if (value > 84.5)
                    {
                        value = 84.5;
                    }
                    else
                    {
                        value = -84.5;

                    }
                    ErrorMap = "Error : Invalid map coordinates";
                }
                else if ((longitude < 175) && (longitude > -175))
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
                if ((value > 175) || (value < -175))
                {
                    if (value > 175)
                    {
                        value = 175;
                    }
                    else
                    {
                        value = -175;
                    }
                    ErrorMap = "Error : Invalid map coordinates";
                }
                else if ((latitude < 84.5) && (latitude > -84.5))
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
                            if (telnetClient.Get(message).Length > 5)
                            {
                                Heading = telnetClient.Get(message).Substring(0, 5);
                            }
                            else
                            {
                                Heading = telnetClient.Get(message);
                            }
                        }
                        SlowServer = null;
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
                            if (telnetClient.Get(message).Length > 5)
                            {
                                VerticalSpeed = telnetClient.Get(message).Substring(0, 5);
                            }
                            else
                            {
                                VerticalSpeed = telnetClient.Get(message);
                            }
                        }
                        SlowServer = null;
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
                            if (telnetClient.Get(message).Length > 5)
                            {
                                GroundSpeed = telnetClient.Get(message).Substring(0, 5);
                            }
                            else
                            {
                                GroundSpeed = telnetClient.Get(message);
                            }
                        }
                        SlowServer = null;
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
                            if (telnetClient.Get(message).Length > 5)
                            {
                                Airspeed = telnetClient.Get(message).Substring(0, 5);
                            }
                            else
                            {
                                Airspeed = telnetClient.Get(message);
                            }
                        }
                        SlowServer = null;
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
                            if (telnetClient.Get(message).Length > 5)
                            {
                                GpsAltitude = telnetClient.Get(message).Substring(0, 5);
                            }
                            else
                            {
                                GpsAltitude = telnetClient.Get(message);
                            }
                        }
                        SlowServer = null;
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
                            if (telnetClient.Get(message).Length > 5)
                            {
                                AttitudeRoll = telnetClient.Get(message).Substring(0, 5);
                            }
                            else
                            {
                                AttitudeRoll = telnetClient.Get(message);
                            }
                        }
                        SlowServer = null;
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
                            if (telnetClient.Get(message).Length > 5)
                            {
                                AttitudePitch = telnetClient.Get(message).Substring(0, 5);
                            }
                            else
                            {
                                AttitudePitch = telnetClient.Get(message);
                            }
                        }
                        SlowServer = null;
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
                            if (telnetClient.Get(message).Length > 5)
                            {
                                AltimeterAltitude = telnetClient.Get(message).Substring(0, 5);
                            }
                            else
                            {
                                AltimeterAltitude = telnetClient.Get(message);
                            }
                        }
                        SlowServer = null;
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
                        SlowServer = null;
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
                        SlowServer = null;
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
                        SlowServer = null;
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
                        SlowServer = null;
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
                        SlowServer = null;
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
                        SlowServer = null;
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
