using UnityEngine;
using UnityEngine.UI;
public class ScoreMagnetEffect : MonoBehaviour
{
    public RectTransform targetUI;
    public float moveSpeed = 300f;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (targetUI == null)
        {
            Debug.LogError("Target UI RectTransform is not assigned.");
            return;
        }
    }

    private void Update()
    {
        if(targetUI == null)
        {
            Vector2 direction = (targetUI.position - rectTransform.position).normalized;
            rectTransform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
            if(Vector2.Distance(rectTransform.position , targetUI.position) < 30f)
            {
                Destroy(gameObject);
            }
        }
    }
}
