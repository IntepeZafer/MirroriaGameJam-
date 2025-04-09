using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public int scoreAdd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(scoreAdd);
        }
    }
}
