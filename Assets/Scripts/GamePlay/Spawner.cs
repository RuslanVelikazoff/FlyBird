using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float minYPosition, maxYPosition;
    public float timeToSpawn;
    private float timer;

    public GameObject pipePrefab;

    private StartData data;

    public void Initialize()
    {
        data = FindObjectOfType<StartData>();
        if (data.easyLevel)
        {
            timeToSpawn = 5;
        }
        if (data.midleLevel)
        {
            timeToSpawn = 3;
        }
        if (data.hardLevel)
        {
            timeToSpawn = 2;
        }
        timer = timeToSpawn;

        Debug.Log("Spawner initialized");
    }

    private void Update()
    {
        if (timer <= 0)
        {
            timer = timeToSpawn;
            GameObject pipe = Instantiate(pipePrefab, transform.position, Quaternion.identity);
            float rand = Random.Range(minYPosition, maxYPosition);
            pipe.transform.position = new Vector3(pipe.transform.position.x, rand, 0);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
