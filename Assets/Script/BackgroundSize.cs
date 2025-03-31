using UnityEngine;

public class BackgroundSize : MonoBehaviour
{
    public Transform targetObject; // Geniþliði referans alýnacak obje

    void Start()
    {
        if (targetObject == null) return;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        float objectWidth = targetObject.localScale.x; // Referans objenin geniþliði
        float spriteWidth = sr.sprite.bounds.size.x;  // Sprite'ýn orijinal geniþliði

        transform.localScale = new Vector3(objectWidth / spriteWidth, transform.localScale.y, 1);
    }
}
