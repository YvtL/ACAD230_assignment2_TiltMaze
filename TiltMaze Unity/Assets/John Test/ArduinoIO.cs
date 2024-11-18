using UnityEngine;
using System.IO.Ports;

public class ArduinoIO : MonoBehaviour
{
    const string portName = "COM4"; // Set this to your correct port
    const int baudRate = 115200;
    SerialPort stream;
    bool portOpen = false;

    void Start()
    {
        try
        {
            stream = new SerialPort(portName, baudRate);
            stream.Open();
            stream.BaseStream.Flush();
            portOpen = true;
        }
        catch (System.Exception e)
        {
            ClosePort();
            Debug.LogError("Could not open port: " + e.Message);
        }
    }

    public string Receive()
    {
        if (portOpen)
        {
            try
            {
                return stream.ReadLine();
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("Failed to read data: " + e.Message);
                return "";
            }
        }
        else
        {
            Debug.LogWarning("Port not open");
            return "";
        }
    }

    public void OnApplicationQuit()
    {
        ClosePort();
    }

    public void ClosePort()
    {
        if (portOpen)
        {
            portOpen = false;
            stream.Close();
            Debug.Log("Port closed");
        }
    }
}
