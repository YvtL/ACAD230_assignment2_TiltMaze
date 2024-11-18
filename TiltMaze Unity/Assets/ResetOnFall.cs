using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnFall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is tagged as "Player" (the ball)
        if (other.CompareTag("Player"))
        {
            // Reload the current scene to reset everything to the starting state
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
