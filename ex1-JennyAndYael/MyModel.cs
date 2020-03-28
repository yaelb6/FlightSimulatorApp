using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ex1_JennyAndYael
{
    class MyModel : IModel
    {
        //INotifyPropertyChanged implementation:
        public event PropertyChangedEventHandler PropertyChanged;

        MyClient telnetClient;
        volatile Boolean stop;
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
