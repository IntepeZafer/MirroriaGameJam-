using UnityEngine;

public class InvertedCharacter : MonoBehaviour
{
    public float jumpHeight;
    public float jumpSpeed;
    private Vector3 startPos;
    public bool isJumping;
    public float jumpProgress;

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (isJumping)
        {
            jumpProgress += Time.deltaTime * jumpSpeed;
            float newY = Mathf.Sin(jumpProgress * Mathf.PI) * -jumpHeight;
            transform.position = startPos + new Vector3(0, newY, 0);
            if (jumpProgress >= 1)
            {
                isJumping = false;
                transform.position = startPos;
            }
        }
    }
    public void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            jumpProgress = 0;
        }
    }
}
