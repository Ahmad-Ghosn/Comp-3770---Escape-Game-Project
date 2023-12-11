using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;   // Array of different objects to spawn
    public Vector2 spawnAreaSize = new Vector2(10f, 10f);   // Size of the bounded spawning area

    private GameObject currentSpawnedObject;  // The currently spawned object

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomObject();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the current spawned object is null (indicating it has been picked up or destroyed)
        if (currentSpawnedObject == null)
        {
            SpawnRandomObject();
        }
    }

    void SpawnRandomObject()
    {
        // Randomly select an object from the array
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

        // Calculate random spawn position within the bounded area
        Vector2 spawnPosition = new Vector2(Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                                            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2));

        // Spawn the selected object at the calculated position
        currentSpawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }

    // Example method for handling player interaction with the spawned object
    public void PlayerInteractedWithObject()
    {
        // Destroy the current object when the player interacts with it
        Destroy(currentSpawnedObject);
    }
}
