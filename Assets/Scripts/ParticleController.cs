using System.Collections;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem particles;    // Reference to the particle system
    public float startDelay = 1f;        // Initial delay before the first emission
    public float delayBetweenBursts = 2f; // Time between each particle burst

    void Start()
    {
        // Get the particle system component
        particles = GetComponent<ParticleSystem>();

        // Disable looping in the main module
        var main = particles.main;
        main.loop = false;

        // Start the coroutine that manages the emission cycle
        StartCoroutine(LoopParticles());
    }

    IEnumerator LoopParticles()
    {
        // Wait before the first emission (start delay)
        yield return new WaitForSeconds(startDelay);

        // Get particle duration from the main module
        var main = particles.main;
        float duration = main.duration;

        while (true)
        {
            // Stop and clear any remaining particles
            particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            // Play the particle system
            particles.Play();

            // Wait for the full duration of the particle emission
            yield return new WaitForSeconds(duration);

            // Wait for the delay between bursts
            yield return new WaitForSeconds(delayBetweenBursts);
        }
    }
}
