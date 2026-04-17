using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float spawnRate = 1.5f;
    public float spawnOffsetY = 6f;
    public float minSpawnRate = 0.5f;
    public float difficultyIncreaseRate = 0.05f;
    private float timer;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        timer += Time.deltaTime;

        spawnRate -= difficultyIncreaseRate * Time.deltaTime;
        spawnRate = Mathf.Clamp(spawnRate, minSpawnRate, 5f);

        if (timer >= spawnRate)
        {
            SpawnCloud();
            timer = 0f;
        }
    }

    void SpawnCloud()
    {
        Vector3 min = cam.ViewportToWorldPoint(new Vector3(0, 1, 0));
        Vector3 max = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        float randomX = Random.Range(min.x, max.x);

        Vector3 spawnPos = new Vector3(
            randomX,
            cam.transform.position.y + spawnOffsetY,
            0
        );

        Instantiate(cloudPrefab, spawnPos, Quaternion.identity);
    }
}