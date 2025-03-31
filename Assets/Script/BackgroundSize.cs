using UnityEngine;

public class BackgroundSize : MonoBehaviour
{
    public Transform targetObject; // Geni�li�i referans al�nacak obje

    void Start()
    {
        if (targetObject == null) return;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        float objectWidth = targetObject.localScale.x; // Referans objenin geni�li�i
        float spriteWidth = sr.sprite.bounds.size.x;  // Sprite'�n orijinal geni�li�i

        transform.localScale = new Vector3(objectWidth / spriteWidth, transform.localScale.y, 1);
    }
}
