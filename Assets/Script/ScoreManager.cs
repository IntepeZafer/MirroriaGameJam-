using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreIconPrefab;
    public RectTransform playerScoreUI;

    public void ShowMagnetScore(Vector3 worldPosition)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
        GameObject icon = Instantiate(scoreIconPrefab, screenPos, Quaternion.identity, GameObject.Find("ScoreTextCanvas").transform);
        ScoreMagnetEffect effect = icon.GetComponent<ScoreMagnetEffect>();
        effect.targetUI = playerScoreUI;
    }
}
