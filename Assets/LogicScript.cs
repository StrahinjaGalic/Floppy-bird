using UnityEngine;
using UnityEngine.UI; // for text
using UnityEngine.SceneManagement; // for scene management

public enum alphaValue
{
    SHRINKING,
    GROWING
}

public class LogicScript : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public GameObject gameOverPanel;
    public GameObject startText;
    public bool isGamePaused = false;
    public bool isRunning = false;

    //used for manipulating start text
    public alphaValue currentAlphaValue;
    public float CommentMinAlpha;
    public float CommentMaxAlpha;
    public float CommentCurrentAlpha;
    public float flashSpeed = 0.5f; // lower = slower flashing


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

    public void quitGame() 
    {
        Application.Quit(); // this will quit the game when running in a build
    }

    public void gameOver()
    { 
        gameOverPanel.SetActive(true);
    }

    public void pauseGame() 
    {
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
    }

    public void DestroyStartText()
    {
        Destroy(startText);
        isRunning = true;
    }

}
