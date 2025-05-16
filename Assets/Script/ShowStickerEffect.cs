using UnityEngine;

public class ShowStickerEffect : MonoBehaviour
{
    public GameObject stickerEffectPrefab;
    public Sprite[] stickerSprite;

    public void ShowEffect(Vector3 position , int score)
    {
        GameObject effectGO = Instantiate(stickerEffectPrefab, position, Quaternion.identity, GameObject.Find("Canvas").transform);
        StickerEffect stickerEffect = effectGO.GetComponent<StickerEffect>();
        if(stickerEffect != null)
        {
            Sprite randomSprite = stickerSprite[Random.Range(0, stickerSprite.Length)];
            stickerEffect.Setup(randomSprite, score);
        }
    }
}
