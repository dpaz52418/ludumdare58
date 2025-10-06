using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "PTS";
    }

    public void RestartButton()
    {
        ScoreManager.Instance.acornScore = 0;
        ScoreManager.Instance.metersAscended = 0;
        SceneManager.LoadScene("MainScene");
        
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("NutCollectorMainMenu");
    }
}
