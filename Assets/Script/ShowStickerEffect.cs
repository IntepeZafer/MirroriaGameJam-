using UnityEngine;
using TMPro;

public class ShowStickerEffect : MonoBehaviour
{
    public GameObject stickerEffectPrefab;           // Sticker prefabý (içinde sprite + puan text olan)
    public Sprite[] stickerSprites;                  // Rastgele atanacak slime sprite'larý
    public Transform effectParent;                   // Canvas üzerindeki parent (UI objesi gibi)
    public int scoreAmount = 10;                     // Gösterilecek puan
    public Sprite[] sprites;                         // Rastgele atanacak sticker sprite'larý

    public void ShowEffect()
    {
        // Sadece belirli tag'e sahip objeler için çalýþtýr
        if (gameObject.tag != "Enemy") return;

        // Sticker prefabýný oluþtur
        GameObject effectGO = Instantiate(stickerEffectPrefab, Vector3.zero, Quaternion.identity, effectParent);

        // Rastgele bir konuma yerleþtir (Canvas içinde)
        effectGO.transform.localPosition = new Vector3(
            Random.Range(-100f, 100f),
            Random.Range(-100f, 100f),
            0f
        );

        // Sprite görselini rastgele seç
        SpriteRenderer spriteRenderer = effectGO.GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer != null && stickerSprites.Length > 0)
        {
            spriteRenderer.sprite = stickerSprites[Random.Range(0, stickerSprites.Length)];
        }

        // Puan yazýsýný göster
        StickerEffect effect = effectGO.GetComponent<StickerEffect>();
        if (effect != null && effect.scoreText != null)
        {
            effect.scoreText.text = $"+{scoreAmount}";
        }
    }
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            Vector3 randomPos = new Vector3(Random.Range(-2f, 2f), Random.Range(0.0f, 0f), 0f);
            GameObject instance = Instantiate(stickerEffectPrefab, randomPos, Quaternion.identity, effectParent);

            var effect = instance.GetComponent<StickerEffect>();
            effect.possibleSprites = sprites;
            effect.Init(randomPos, scoreAmount);
        }
    }

}


