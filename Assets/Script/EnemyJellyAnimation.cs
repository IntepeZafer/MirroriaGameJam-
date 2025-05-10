using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float wobbleScale;
    public float wobbleSpeed;

    private void Start()
    {
        StartWobble();
    }

    public void StartWobble()
    {
        LeanTween.scale(gameObject, new Vector3(1 + wobbleScale, 1f - wobbleScale, 1f), wobbleSpeed)
            .setEaseInOutSine()
            .setLoopPingPong();
    }
}
