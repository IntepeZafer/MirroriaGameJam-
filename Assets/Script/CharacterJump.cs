using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public AudioClip jumpSound;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            animator.ResetTrigger("isJumping");
            animator.SetTrigger("isJumping");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 7f);
            if(jumpSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }
    }
}
