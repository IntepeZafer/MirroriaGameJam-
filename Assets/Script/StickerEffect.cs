using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class StickerEffect : MonoBehaviour
{
    public Image stickerImage;
    public TextMeshProUGUI scoreText;
    public float fadeDuration = 0.5f;
    public float scaleDuration = 0.5f;


    public void Setup(Sprite sprite ,int score)
    {
        stickerImage.sprite = sprite;
        scoreText.text = $"+ {score}";
        StartCoroutine(AnimateSticker());
    }
    private IEnumerator AnimateSticker() 
    {
        stickerImage.color = new Color(1, 1, 1, 0);
        scoreText.color = new Color(1, 1, 1, 0);
        transform.localScale = Vector3.zero;

        Color randomColor = GetRandomNonBlackColor();
        stickerImage.color = randomColor;
        float time = 0;

        while(time  < fadeDuration)
        {
            float t = time / fadeDuration;
            stickerImage.color = new Color(randomColor.r, randomColor.g, randomColor.b, t);
            scoreText.color = new Color(1, 1, 1, t);
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            time += Time.deltaTime;
            yield return null;
        }
        stickerImage.color = new Color(randomColor.r, randomColor.g, randomColor.b, 1);
        scoreText.color = new Color(1, 1, 1, 1);
        transform.localScale = Vector3.one;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private Color GetRandomNonBlackColor()
    {
        Color color;
        do
        {
            color = new Color(Random.value, Random.value, Random.value);
        } while (color == Color.black || (color.r < 0.2f && color.g < 0.2f && color.b < 0.2f));
        return color;
    }
    private void Start()
    {
        Destroy(gameObject, 1.5f); 
    }
}
