using UnityEngine;
using System.IO.Ports;

public class ArduinoIO : MonoBehaviour
{
    const string portName = "/dev/cu.usbmodem21031";
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
            print(e);
        }
    }

    public void SendString(string message)
    {
        if (portOpen)
        {
            stream.WriteLine(message);
            stream.BaseStream.Flush();
        }
        else
        {
            print("port not open");
        }
    }

    public void SendByte(byte[] message)
    {
        if (portOpen)
        {
            stream.Write(message, 0, message.Length);
            stream.BaseStream.Flush();
        }
        else
        {
            print("port not open");
        }
    }


    public string Receive()
    {
        if (portOpen)
        {
            return stream.ReadLine();
        }
        else
        {
            print("port not open");
            return "";
        }
    }

    public void OnApplicationQuit()
    {
        ClosePort();
    }

    public void ClosePort()
    {
        portOpen = true;
        stream.Close();
        print("Port closed");
    }
}