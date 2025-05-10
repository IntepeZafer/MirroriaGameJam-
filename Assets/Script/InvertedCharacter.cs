using UnityEngine;

public class InvertedCharacter : MonoBehaviour
{
    public float jumpHeight;
    public float jumpSpeed;
    private Vector3 startPos;
    public bool isJumping;
    public float jumpProgress;
    private Rigidbody2D Rb;
    private JumpEffectTrigger jumpEffectTrigger;

    private void Start()
    {
        startPos = transform.position;
        Rb = GetComponent<Rigidbody2D>();
        jumpEffectTrigger = GetComponent<JumpEffectTrigger>();
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
        if (Input.GetMouseButtonDown(1))
        {
            JumpEffect();
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
    void JumpEffect()
    {
        Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, 8f);
        if (jumpEffectTrigger != null)
        {
            jumpEffectTrigger.TriggerJumpEffect();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            FindAnyObjectByType<GameOverManager>().ShowGameOver();
        }
    }
}
