using UnityEngine;

public class GameOverToothWobble : MonoBehaviour
{
    public float positionIndensity;
    public float positionSpeed;
    public float colorIndensity;
    public float colorSpeed;

    private Vector3 originalPosition; 
    private SpriteRenderer spriteRenderer; 
    private Color originalColor; 

    private void Start()
    {
        originalPosition = transform.localPosition;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    private void Update()
    {
        float wobbleX = Mathf.Sin(Time.time * positionSpeed) * positionIndensity;
        float wobbleY = Mathf.Cos(Time.time * positionSpeed * 1.3f) * positionIndensity;
        transform.localPosition = originalPosition + new Vector3(wobbleX, wobbleY, 0f);

        if(spriteRenderer != null)
        {
            float lerp = (Mathf.Sin(Time.time * colorSpeed) + 1f) * 2f;
            spriteRenderer.color = Color.Lerp(originalColor , Color.white, lerp) * colorIndensity;
        }
    }
}
