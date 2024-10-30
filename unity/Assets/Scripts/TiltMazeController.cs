using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class TiltMazeController : MonoBehaviour
{
    public float tiltSpeed = 20f; //speed of tilt
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get input from keys for testing purposes
        //later will be replaced by arduino input
        float tiltX = Input.GetAxis("Horizontal")*tiltSpeed*Time.deltaTime;
        float tiltZ = Input.GetAxis("Vertical")*tiltSpeed*Time.deltaTime;

        //apply rotation
        transform.Rotate (tiltZ, 0, -tiltX);
    }
}
