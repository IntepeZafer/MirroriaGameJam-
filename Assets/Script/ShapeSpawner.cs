using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ShapeSpawner : MonoBehaviour
{
    public GameObject shapePrefab;
    public RectTransform spawnArea;
    public int shapeCount;
    public float spawnRate;

    private void Start()
    {
        if (shapePrefab == null || spawnArea == null)
        {
            Debug.LogError("❌ ShapePrefab veya SpawnArea atanmadı! Lütfen Inspector'dan kontrol et.");
            return;
        }
        StartCoroutine(SpawnShapes());
    }
    IEnumerator SpawnShapes()
    {
        while (true)
        {
            SpawnShape();
            yield return new WaitForSeconds(spawnRate);
        }
    }
    void SpawnShape()
    {
        GameObject newShape = Instantiate(shapePrefab, spawnArea);
        RectTransform rectTransform = newShape.GetComponent<RectTransform>();
        // Rastgele konum belirle
        float x = Random.Range(-spawnArea.rect.width / 2, spawnArea.rect.width / 2);
        float y = Random.Range(-spawnArea.rect.height / 2, spawnArea.rect.height / 2);
        rectTransform.anchoredPosition = new Vector2(x, y);
        Debug.Log("✅ Prefab oluşturuldu: " + newShape.name);
    }
}
