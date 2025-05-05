using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int scoreToAdd = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 effectPosition = transform.position + Vector3.up * 1f;
            scoreManager.ShowScoreEffect(effectPosition, scoreToAdd);
        }
    }
}
