using UnityEngine;
using System.Collections;
public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform spawnPoint;
    public float minSpawnInterval;
    public float maxSpawnInterval;
    public float objectLifetime;
    public float moveSpeed; // Nesnelerin kayma hýzý

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

                // Nesneye hareket scriptini ekle ve hýzýný ayarla
                MoveObject moveScript = spawnedObject.AddComponent<MoveObject>();
                moveScript.speed = moveSpeed;

                // Belirtilen süre sonra yok et
                Destroy(spawnedObject, objectLifetime);
            }
        }
    }
}
