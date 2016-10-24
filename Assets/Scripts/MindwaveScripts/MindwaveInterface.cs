using UnityEngine;
using System.Net.Sockets;
using System.IO;
using System.Text;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using System.Collections;
using System;

public class MindwaweInterface : MonoBehaviour
{
    public static MindwaweInterface Instance { get; private set; }

    public static float lowBetaEegValue { get; private set; }
    public static float highBetaEegValue { get; private set; }

    private TcpClient client;
    private Stream stream;
    private byte[] buffer;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

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

            InvokeRepeating("ReadData", 0.1f, 0.02f);
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
                    if (primary.Contains("eegPower"))
                    {
                        IDictionary eegPowers = (IDictionary)primary["eegPower"];

                        lowBetaEegValue = float.Parse(eegPowers["lowBeta"].ToString());
                        highBetaEegValue = float.Parse(eegPowers["highBeta"].ToString());
                    }
                }
            }
            catch (Exception e) { }
        }
    }
}