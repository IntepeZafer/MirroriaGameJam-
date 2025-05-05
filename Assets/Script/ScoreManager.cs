using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public GameObject explosionPrefab;
    public TextMeshProUGUI totalScoreText;
    private int totalScore = 0;

    public void ShowScoreEffect(Vector3 worldPosition , int scoreAmount)
    {
        Instantiate(explosionPrefab, worldPosition, Quaternion.identity);
        TextMeshProUGUI scoreText = Instantiate(totalScoreText, worldPosition, Quaternion.identity, transform);
        scoreText.text = "+" + scoreAmount.ToString();
        LeanTween.moveY(scoreText.gameObject, worldPosition.y + 2f, 1f).setEaseInOutQuad();
        LeanTween.alphaText(scoreText.rectTransform, 0, 1f);
        Destroy(scoreText.gameObject, 1f);
        totalScore += scoreAmount;
        totalScoreText.text = "Score: " + totalScore;
        Debug.Log(worldPosition);
    }
}
