using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the pipe moves
    public float destroyX = -45; // X position at which the pipe will be destroyed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime; //physics runs on its own clock this does not hence delta time is needed
        if(transform.position.x < destroyX)
        {
            Destroy(gameObject); // Destroy the pipe when it goes off screen
        }

    }
}
