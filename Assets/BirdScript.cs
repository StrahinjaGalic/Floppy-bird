using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public float flapForce = 10;
    public LogicScript logic;
    public bool isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); 
        logic.pauseGame(); //game is paused until user input :3
        logic.CommentMinAlpha = 0.2f;
        logic.CommentMaxAlpha = 1f;
        logic.CommentCurrentAlpha = 1f;
        logic.currentAlphaValue = alphaValue.SHRINKING;

    }

    // Update is called once per frame
    void Update()
    {

        if (logic.isRunning == false) 
        {
            FlashingText();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGameOver == false)
        {
            if (logic.isRunning == false)
            {
                logic.DestroyStartText();
            }

            if (logic.isGamePaused == true)
            {
                logic.resumeGame();
            }

            rigidBody2D.linearVelocity = Vector2.up * flapForce;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            logic.gameOver();
            isGameOver = true;
    }

    public void FlashingText()
    {
        if (logic.currentAlphaValue == alphaValue.SHRINKING)
        {
            logic.CommentCurrentAlpha -= logic.CommentCurrentAlpha - 0.0025f;
            logic.startText.GetComponent<Text>().color = new Color(Color.white.r, Color.white.b, Color.white.g, logic.CommentCurrentAlpha);
            if (logic.CommentCurrentAlpha <= logic.CommentMinAlpha)
            {
                logic.currentAlphaValue = alphaValue.GROWING;
            }
        }
        else if (logic.currentAlphaValue == alphaValue.GROWING)
        {
            logic.CommentCurrentAlpha = logic.CommentCurrentAlpha + 0.0025f;
            logic.startText.GetComponent<Text>().color = new Color(Color.white.r, Color.white.b, Color.white.g, logic.CommentCurrentAlpha);
            if (logic.CommentCurrentAlpha >= logic.CommentMaxAlpha)
            {
                logic.currentAlphaValue = alphaValue.SHRINKING;
            }
        }
    }

}
