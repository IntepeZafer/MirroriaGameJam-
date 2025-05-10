using UnityEngine;

public class JumpEffectTrigger : MonoBehaviour
{
    public ParticleSystem jumpEffectPrefab;
    public Transform jumpEffectPoint;

    public void TriggerJumpEffect()
    {
        if (jumpEffectPrefab != null && jumpEffectPoint != null)
        {
            Instantiate(jumpEffectPrefab, jumpEffectPoint.position, Quaternion.identity);
        }
            LeanTween.scale(gameObject, new Vector3(1.1f, 1.9f, 1f), 0.20f).setEaseOutQuad().setOnComplete(() =>
        {
            LeanTween.scale(gameObject, Vector3.one, 0.1f).setEaseInQuad();
        });
    }
}
