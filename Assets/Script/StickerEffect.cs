using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StickerEffect : MonoBehaviour
{
    public Image stickerImage;
    public TextMeshProUGUI scoreText;


    public void Setup(Sprite sprite ,int score)
    {
        stickerImage.sprite = sprite;
        scoreText.text = $"+{score}";
    }
    private void Start()
    {
        Destroy(gameObject, 1.5f); 
    }
}
