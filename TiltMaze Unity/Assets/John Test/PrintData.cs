using System.Collections;
using UnityEngine;

public class PrintData : MonoBehaviour
{
    string values;
    ArduinoIO arduinoIO;
    void Start()
    {
        arduinoIO = GetComponent<ArduinoIO>();
        StartCoroutine(ReadData());
    }

    IEnumerator ReadData()
    {
        while (true)
        {
            values = arduinoIO.Receive();
            if (values.Length == 5)
            {
                int X = int.Parse(values[0].ToString());       // Read the X tilt sensor value (1 or 0)
                int NegX = int.Parse(values[1].ToString());    // Read the -X tilt sensor value (1 or 0)
                int Y = int.Parse(values[2].ToString());       // Read the Y tilt sensor value (1 or 0)
                int NegY = int.Parse(values[3].ToString());

                print(NegY + ", " + X + ", " + NegX + "," + NegY);
            }

            yield return null;
        }
    }
}