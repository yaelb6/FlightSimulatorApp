﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Configuration;

namespace ex1_JennyAndYael
{
    class MyClient
    {
        TcpClient tcpClient;
        NetworkStream stream;
        string connectionIp;
        int connectionPort;

        public MyClient()
        {
            //ip and port from app config
            connectionIp = ConfigurationManager.ConnectionStrings["ip"].ConnectionString.ToString();
            connectionPort = Convert.ToInt32(ConfigurationManager.ConnectionStrings["port"].ConnectionString.ToString());
            

        }
        public void connect(string ip, int port)
        {
            tcpClient = new TcpClient(connectionIp, connectionPort);
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
            Console.WriteLine("Sent: {0}", message);

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

            Console.WriteLine("Received: {0}", responseData);
            return responseData;
        }

       public void disconnect()
        {
            tcpClient.Close();
        }

    }
}