using UnityEngine;
using TMPro;

public class ShowStickerEffect : MonoBehaviour
{
    public GameObject stickerEffectPrefab;           // Sticker prefab� (i�inde sprite + puan text olan)
    public Sprite[] stickerSprites;                  // Rastgele atanacak slime sprite'lar�
    public Transform effectParent;                   // Canvas �zerindeki parent (UI objesi gibi)
    public int scoreAmount = 10;                     // G�sterilecek puan
    public Sprite[] sprites;                         // Rastgele atanacak sticker sprite'lar�

    public void ShowEffect()
    {
        // Sadece belirli tag'e sahip objeler i�in �al��t�r
        if (gameObject.tag != "Enemy") return;

        // Sticker prefab�n� olu�tur
        GameObject effectGO = Instantiate(stickerEffectPrefab, Vector3.zero, Quaternion.identity, effectParent);

        // Rastgele bir konuma yerle�tir (Canvas i�inde)
        effectGO.transform.localPosition = new Vector3(
            Random.Range(-100f, 100f),
            Random.Range(-100f, 100f),
            0f
        );

        // Sprite g�rselini rastgele se�
        SpriteRenderer spriteRenderer = effectGO.GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer != null && stickerSprites.Length > 0)
        {
            spriteRenderer.sprite = stickerSprites[Random.Range(0, stickerSprites.Length)];
        }

        // Puan yaz�s�n� g�ster
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


