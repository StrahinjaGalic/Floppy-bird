using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe; // Reference to the pipe prefab
    public float spawnRate = 1; // Rate at which pipes are spawned (in seconds)
    private float timer = 0; // Timer to track the spawn rate
    public float spawnHeight = 10; // Height at which the pipe spawns

    void Start()
    {
        spawnPipe(); // Spawn the first pipe immediately
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime; // Increment the timer by the time since the last frame
        }
        else
        {
            spawnPipe();
            timer = 0; // Reset the timer after spawning a pipe
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - spawnHeight;
        float highestPoint = transform.position.y + spawnHeight;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint,highestPoint), 0), transform.rotation);
    }


}