using UnityEngine;
using UnityEngine.UI;

public class NeonMaterial : MonoBehaviour
{
    public Text uiText;
    public float colorChangeSpeed;
    public float hue = 0f;

    private void Start()
    {
        if (uiText == null)
        {
            uiText = GetComponent<Text>();
        }
    }

    private void Update()
    {
        hue += Time.deltaTime * colorChangeSpeed;
        if(hue > 1f)
        {
            hue = 0f;
        }
        Color newColor = Color.HSVToRGB(hue, 1f, 1f);
        uiText.color = newColor;
    }
}
