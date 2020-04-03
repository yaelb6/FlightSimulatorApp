using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Configuration;

namespace ex1_JennyAndYael
{
    public class MyClient
    {
        TcpClient tcpClient;
        NetworkStream stream;
        string connectionIp;
        int connectionPort;

        public MyClient()
        {
            //ip and port from app config
            connectionIp = Properties.Settings.Default.ServerIPValue;
            connectionPort = Convert.ToInt32(Properties.Settings.Default.PortValue);

        }
        public void connect()
        {
            tcpClient = new TcpClient(connectionIp, connectionPort);
            tcpClient.ReceiveTimeout = 10000;
        }

        public void set(string message)
        {
            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            // Get a client stream for reading and writing.
            stream = tcpClient.GetStream();
            // Send the message to the connected TcpServer.
            stream.Write(data, 0, data.Length);
            String responseData = String.Empty;
            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
        }

        public string get(string message)
        {
            // Receive the TcpServer.response.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            stream = tcpClient.GetStream();
            // Send the message to the connected TcpServer - the server need to know what kind of data I want. 
            stream.Write(data, 0, data.Length);
            String responseData = String.Empty;
            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            return responseData;
        }

       public void disconnect()
        {
            tcpClient.Close();
        }

    }
}
