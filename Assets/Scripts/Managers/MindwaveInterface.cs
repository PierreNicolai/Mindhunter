﻿using System.Net.Sockets;
using System.IO;
using System.Text;
using Jayrock.Json.Conversion;
using System.Collections;
using System;

namespace MindHunter.Managers
{
    public class MindwaveInterface : PersistentSingleton<MindwaveInterface>
    {
        public int attentionValue { get; private set; }
        public int meditationValue { get; private set; }

        private TcpClient client;
        private Stream stream;
        private byte[] buffer;

        // Use this for initialization
        void Start()
        {
            Connect();
        }

        void OnApplicationQuit()
        {
            Disconnect();
        }

        public void Connect()
        {
            if (!IsInvoking("ReadData"))
            {
                client = new TcpClient("127.0.0.1", 13854);
                stream = client.GetStream();
                buffer = new byte[1024];
                byte[] inputBuffer = Encoding.ASCII.GetBytes(@"{""enableRawOutput"": true, ""format"": ""Json""}");
                stream.Write(inputBuffer, 0, inputBuffer.Length);

                InvokeRepeating("ReadData", 0.1f, 0.1f);
            }
        }

        public void Disconnect()
        {
            if (IsInvoking("ReadData"))
            {
                CancelInvoke("ReadData");
                stream.Close();
            }
        }

        private void ReadData()
        {
            if (stream.CanRead)
            {
                try
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string[] packets = Encoding.ASCII.GetString(buffer, 0, bytesRead).Split('\r');

                    foreach (string packet in packets)
                    {
                        if (packet.Length == 0)
                            continue;
                        IDictionary primary = (IDictionary)JsonConvert.Import(typeof(IDictionary), packet);

                        if (primary.Contains("eSense"))
                        {
                            IDictionary eSense = (IDictionary)primary["eSense"];

                            attentionValue = int.Parse(eSense["attention"].ToString());
                            meditationValue = int.Parse(eSense["meditation"].ToString());
                        }
                    }
                }
                catch (Exception e) { }
            }
        }
    }
}
