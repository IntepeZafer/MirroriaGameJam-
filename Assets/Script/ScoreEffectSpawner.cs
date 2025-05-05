using UnityEngine;
using TMPro;
public class ScoreEffectSpawner : MonoBehaviour
{
    public GameObject scoreEffectPrefab;
    public Canvas canvas;

    public void SpawnScoreEffect(int score)
    {
        Vector2 randomScreenPos = new Vector2(Random.Range(100, Screen.width - 100), Random.Range(100, Screen.height - 100));
        RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.GetComponent<RectTransform>(), randomScreenPos, null, out Vector3 worldPos);

        GameObject instance = Instantiate(scoreEffectPrefab, worldPos, Quaternion.identity);

        TMP_Text text = instance.GetComponentInChildren<TMP_Text>();
        if (text != null)
        {
            text.text = "+" + score.ToString();
        }
        Destroy(instance, 1f); 
    }
}
