using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalTrigger : MonoBehaviour
{
    public Text winText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            winText.text = "YOU WIN!";
            Time.timeScale = 0; //freeze the game
        }
    }
}
