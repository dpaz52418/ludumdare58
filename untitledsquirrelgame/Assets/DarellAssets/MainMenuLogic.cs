using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuLogic : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
