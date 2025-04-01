using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class FloatingShape : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    private Vector2 direction;
    private RectTransform rectTransform;
    private Image image;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        StartCoroutine(FadeOutAndDestroy());
    }
    private void Update()
    {
        rectTransform.anchoredPosition += direction * speed * Time.deltaTime;
    }
    IEnumerator FadeOutAndDestroy()
    {
        yield return new WaitForSeconds(lifeTime - 1.5f);
        float fadeDuration = 1.5f;
        float elapsedTime = 0f;
        while(elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f , 0f , elapsedTime / fadeDuration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            yield return null;
        }
        Destroy(gameObject);
    }
}
