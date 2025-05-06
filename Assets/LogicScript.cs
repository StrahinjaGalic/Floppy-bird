using UnityEngine;
using UnityEngine.UI; // for text
using UnityEngine.SceneManagement; // for scene management

public class LogicScript : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public GameObject gameOverPanel;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
       score += 1;
       scoreText.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    { 
        gameOverPanel.SetActive(true);
    }
}
