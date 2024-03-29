﻿using System;
using System.Net.Sockets;

namespace FlightSimulator
{
    public class MyClient
    {
        TcpClient tcpClient;
        NetworkStream stream;
        string connectionIp;
        int connectionPort;

        public MyClient()
        {
            //Define Ip and port from app config.
            connectionIp = Properties.Settings.Default.ServerIPValue;
            connectionPort = Convert.ToInt32(Properties.Settings.Default.PortValue);

        }
        //This method defines the connection to the server.
        public void Connect()
        {
            tcpClient = new TcpClient(connectionIp, connectionPort);
            tcpClient.ReceiveTimeout = 9500;
        }
        //This method set the message to the server.
        public string Set(string message)
        {
            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            // Get a client stream for reading and writing.
            try
            {
                stream = tcpClient.GetStream();
            }
            catch (InvalidOperationException)
            {
                return "disconnected";
            }
            // Send the message to the connected TcpServer.
            stream.Write(data, 0, data.Length);
            String responseData = String.Empty;
            // Read the first batch of the TcpServer response bytes.
            if (stream.CanRead)
            {
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                return responseData;
            }
            else
            {
                return "disconnected";
            }
        }
        //This method get the data from the server.
        public string Get(string message)
        {
            // Receive the TcpServer.response.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            try
            {
                stream = tcpClient.GetStream();
            }
            catch (InvalidOperationException)
            {
                return "disconnected";
            }
            // Send the message to the connected TcpServer - the server need to know what kind of data I want. 
            stream.Write(data, 0, data.Length);
            String responseData = String.Empty;
            // Read the first batch of the TcpServer response bytes.
            if (stream.CanRead)
            {
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                return responseData;
            }
            else
            {
                return "disconnected";
            }

        }
        //This method close the connection with the server.
        public void Disconnect()
        {
            tcpClient.Close();
        }

    }
}
