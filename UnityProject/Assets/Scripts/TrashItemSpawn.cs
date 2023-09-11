using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItemSpawn : MonoBehaviour
{
    public float spawnWidth = 1;
    public float spawnRate = 1;
    public GameObject TrashItemPrefab;

    private float lastSpawnTime = 0;

    /// <summary>
    /// Update is called by Unity. This will spawn asteroids while the game is in play mode.
    /// </summary>
    void Update()
    {
        // this is a simple timer structure that executes every 1/spawnRate seconds. This means it spawns spawnRate asteroids every second.
        if (lastSpawnTime + 1 / spawnRate < Time.time)
        {
            lastSpawnTime = Time.time;
            Vector3 spawnPosition = transform.position;
            spawnPosition += new Vector3(Random.Range(-spawnWidth, spawnWidth), 0, 0);
            // the Instatiate function creates a new GameObject copy (clone) from a Prefab at a specific location and orientation.
            Instantiate(TrashItemPrefab, spawnPosition, Quaternion.identity);
        }
    }

    /// <summary>
    /// Helper function called by unity to draw gizmos for debugging and orientation in the scene view. Is not part of any game logic.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position - new Vector3(spawnWidth, 0, 0), transform.position + new Vector3(spawnWidth, 0, 0));
        Gizmos.DrawLine(transform.position - new Vector3(spawnWidth, 1, 0), transform.position - new Vector3(spawnWidth, -1, 0));
        Gizmos.DrawLine(transform.position + new Vector3(spawnWidth, 1, 0), transform.position + new Vector3(spawnWidth, -1, 0));
    }
}
