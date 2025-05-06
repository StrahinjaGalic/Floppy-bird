using UnityEngine;

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

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGameOver == false)
        {
            rigidBody2D.linearVelocity = Vector2.up * flapForce;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            logic.gameOver();
            isGameOver = true;
    }

}
