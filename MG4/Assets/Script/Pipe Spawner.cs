using System.Security.Cryptography;
using UnityEngine;
public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnInterval = 2.5f;
    public float spawnX = 6f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), 1.5f, spawnInterval);
    }

    void SpawnPipe()
    {
        Camera cam = Camera.main;

        float rightEdge =
            cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        Vector3 pos = new Vector3(
            rightEdge + 3f, 
            0f,
            0f
        );

        Instantiate(pipePrefab, pos, Quaternion.identity);
    }
}