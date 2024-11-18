using UnityEngine;
using UnityEngine.SceneManagement;

public class BallFallReset : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the ball collides with the ground plane
        if (other.CompareTag("Boundary"))
        {
            // Reload the current scene to reset the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
