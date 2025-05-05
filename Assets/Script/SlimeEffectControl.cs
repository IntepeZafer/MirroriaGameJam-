using UnityEngine;

public class SlimeEffectControl : MonoBehaviour
{
    public ParticleSystem slimeParticles;

    private void Update()
    {
        if (Mathf.Abs(GetComponent<Rigidbody2D>().linearVelocity.x) > 0.1f)
        {
            if (!slimeParticles.isPlaying)
                slimeParticles.Play();
        }
        else
        {
            if (slimeParticles.isPlaying)
                slimeParticles.Stop();
        }
    }
}
