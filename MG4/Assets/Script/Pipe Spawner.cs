using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    [SerializeField] float spawnRate = 2f;
    [SerializeField] float minY = -1f;
    [SerializeField] float maxY = 3f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), 1f, spawnRate);
        Time.timeScale = 1;
    }

    void SpawnPipe()
    {
        Debug.Log("Spawn Pipe"); 

        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0f);

        Instantiate(pipePrefab, spawnPos, Quaternion.identity);
    }
}