using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoInputReader : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM3",9600);
    public float tiltSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        serialPort.Open();  // Open the serial port
    }

    // Update is called once per frame
    void Update()
    {

        if (serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine();
                string[] values = data.Split(',');

                if (values.Length == 2)
                {
                    int tiltLeftRight = int.Parse(values[0]);
                    int tiltForward = int.Parse(values[1]);

                    // Map the sensor readings to tilt controls in Unity
                    float tiltX = tiltLeftRight == 1 ? tiltSpeed * Time.deltaTime : 0;  // Tilt on X-axis
                    float tiltZ = tiltForward == 1 ? tiltSpeed * Time.deltaTime : 0;    // Tilt on Z-axis

                    // Rotate the maze based on Arduino input
                    GameObject mazePivot = GameObject.Find("MazePivot");
                    mazePivot.transform.Rotate(tiltX, 0, tiltZ);
                }
            }
            catch (System.Exception)
            {
                // Handle any exceptions from parsing
            }
        }
    }

    private void OnApplicationQuit()
    {
        serialPort.Close();  // Close the serial port when quitting the application
    }
        
}
