using TMPro;
using UnityEngine;
public class StickerEffect : MonoBehaviour
{
    public float duration = 1f;
    public float timer = 0f;

    public SpriteRenderer spriteRenderer;
    public TMP_Text scoreText;
    public Sprite[] possibleSprites;

    private Vector3 startScale;
    private Vector3 targetScale;

    public void Init(Vector3 position, int score)
    {
        transform.position = position;
        if (possibleSprites.Length > 0)
            spriteRenderer.sprite = possibleSprites[Random.Range(0, possibleSprites.Length)];
 
        scoreText.text = "+" + score;
        scoreText.rectTransform.localPosition = Vector3.zero;

        startScale = Vector3.zero;
        targetScale = Vector3.one;
        transform.localScale = startScale;
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        float floatingTime = timer / duration;

        if (floatingTime < 0.3f)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale * 1.2f, floatingTime / 0.3f);
        }
        else if (floatingTime < 0.6f)
        {
            transform.localScale = Vector3.Lerp(targetScale * 1.2f, targetScale, (floatingTime - 0.3f) / 0.3f);
        }

        if (floatingTime >= 1f)
        {
            Destroy(gameObject);
        }
        if (scoreText == null)
            scoreText = GetComponentInChildren<TextMeshProUGUI>();
    }
}

