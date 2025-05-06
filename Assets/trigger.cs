using UnityEngine;

public class trigger : MonoBehaviour
{
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); //added a tag for logic acript which was used to locate said script and use it in prefab good stuff
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) {
            logic.addScore(1);
        }
    }

}
