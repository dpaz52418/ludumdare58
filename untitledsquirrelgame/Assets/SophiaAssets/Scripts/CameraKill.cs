using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraKill : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit the camera boundary!");
            // Example death behavior:
            PlayerDeath(other.gameObject);
        }
    }

    public void PlayerDeath(GameObject player)
    {
        // Disable player
        // player.SetActive(false);

        player.SetActive(false);
        SceneManager.LoadScene("GameOver");
     }
}
