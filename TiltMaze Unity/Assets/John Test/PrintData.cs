using System.Collections;
using UnityEngine;

public class PrintData : MonoBehaviour
{
    public float tiltAngle = 20f; // Maximum angle to tilt the maze in each direction
    private ArduinoIO arduinoIO;
    private Transform mazePivot;

    private float currentTiltX = 0f; // Track current tilt along X-axis
    private float currentTiltZ = 0f; // Track current tilt along Z-axis
    private int X = 0; // Arduino input for X-axis tilt
    private int Y = 0; // Arduino input for Y-axis tilt

    void Start()
    {
        arduinoIO = GetComponent<ArduinoIO>();
        mazePivot = GameObject.Find("MazePivot").transform; // Find the maze pivot object
        StartCoroutine(ReadData());
    }

    IEnumerator ReadData()
    {
        while (true)
        {
            string values = arduinoIO.Receive(); // Get the data from the Arduino
            if (!string.IsNullOrEmpty(values))
            {
                string[] splitValues = values.Split(','); // Split the data by comma

                if (splitValues.Length == 2) // Ensure we received both X and Y values
                {
                    X = int.Parse(splitValues[0]) - 1; // Convert 0,1,2 to -1,0,1 for X
                    Y = int.Parse(splitValues[1]) - 1; // Convert 0,1,2 to -1,0,1 for Y
                }
            }
            yield return null;
        }
    }

    void Update()
    {
        // Calculate the target tilt based on the Arduino input and tilt angle
        float targetTiltX = Y * tiltAngle; // Forward/backward tilt based on Y input
        float targetTiltZ = X * tiltAngle; // Left/right tilt based on X input

        // Smoothly transition to the target tilt with a small speed multiplier
        currentTiltX = Mathf.Lerp(currentTiltX, targetTiltX, Time.deltaTime * 2f);
        currentTiltZ = Mathf.Lerp(currentTiltZ, targetTiltZ, Time.deltaTime * 2f);

        // Clamp the tilt to avoid extreme angles
        currentTiltX = Mathf.Clamp(currentTiltX, -tiltAngle, tiltAngle);
        currentTiltZ = Mathf.Clamp(currentTiltZ, -tiltAngle, tiltAngle);

        // Apply the clamped rotation to the maze
        mazePivot.localRotation = Quaternion.Euler(currentTiltX, 0, currentTiltZ);
    }
}
