using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    private void Start()
    {
        if(transform.position.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
