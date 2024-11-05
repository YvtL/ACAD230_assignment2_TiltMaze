
using UnityEngine;
using System.IO.Ports;

public class ArduinoTiltController : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM4", 115200); // Replace "COM3" with your actual port if different
    public float tiltSpeed = 30f; // Speed of tilting

    void Start()
    {
        serialPort.Open();  // Open the serial port to start reading data
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine();  // Read a line of data from the serial port
                string[] values = data.Split(' ');   // Split the data by spaces to get the four values

                if (values.Length == 4)
                {
                    int X = int.Parse(values[0]);       // Read the X tilt sensor value (1 or 0)
                    int NegX = int.Parse(values[1]);    // Read the -X tilt sensor value (1 or 0)
                    int Y = int.Parse(values[2]);       // Read the Y tilt sensor value (1 or 0)
                    int NegY = int.Parse(values[3]);    // Read the -Y tilt sensor value (1 or 0)

                    // Calculate tilt based on sensor values
                    float tiltX = (X == 1 ? tiltSpeed * Time.deltaTime : 0) - (NegX == 1 ? tiltSpeed * Time.deltaTime : 0);
                    float tiltZ = (Y == 1 ? tiltSpeed * Time.deltaTime : 0) - (NegY == 1 ? tiltSpeed * Time.deltaTime : 0);

                    // Apply the calculated tilt to the maze pivot
                    transform.Rotate(tiltX, 0, tiltZ);
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogWarning("Failed to read data from Arduino: " + ex.Message);
            }
        }
    }

    private void OnApplicationQuit()
    {
        if (serialPort.IsOpen)
        {
            serialPort.Close();  // Close the serial port when quitting the application
        }
    }
}
