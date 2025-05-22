using UnityEngine;
using System.Collections;
public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform spawnPoint;
    public float minSpawnInterval;
    public float maxSpawnInterval;
    public float objectLifetime;
    public float moveSpeed;
    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            float randomTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(randomTime);
            if (objectsToSpawn.Length > 0)
            {
                int randomIndex = Random.Range(0, objectsToSpawn.Length);
                GameObject spawnedObject = Instantiate(objectsToSpawn[randomIndex], spawnPoint.position, Quaternion.identity);

                if(spawnPoint.position.y > 0)
                {
                    spawnedObject.transform.rotation = Quaternion.Euler(180f, 0f, 0f);
                }
                MoveObject moveScript = spawnedObject.AddComponent<MoveObject>();
                moveScript.speed = moveSpeed;
                Destroy(spawnedObject, objectLifetime);
            }
        }
    }
}
