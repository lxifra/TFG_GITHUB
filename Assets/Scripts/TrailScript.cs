using UnityEngine;
using UnityEngine.Splines;
using System.Collections;

[RequireComponent(typeof(TrailRenderer))]
public class TrailScript : MonoBehaviour
{
    [Header("Spline Settings")]
    public SplineContainer splineContainer;

    [Header("Timing (per object)")]
    public float speed = 2f;
    public float delayBetweenBeats = 1f;
    public float initialDelay = 0f;
    public float pauseAtEndDuration = 1f;
    public float Lifetime = 4f;

    [Header("Trail Appearance")]
    public float startWidth = 0.2f;
    public float endWidth = 0.2f;
    public Color startColor = Color.red;
    public Color endColor = Color.red;

    [Header("Advanced Smoothing")]
    public int substepsPerFrame = 5;

    private float progress = 0f;
    private TrailRenderer trail;
    private int cycleCount = 0;
    private bool isRunning = false;

    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        trail.time = Lifetime;

        trail.widthCurve = new AnimationCurve(
            new Keyframe(0f, startWidth),
            new Keyframe(1f, endWidth)
        );

        trail.material = new Material(Shader.Find("Sprites/Default"));

        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] {
                new GradientColorKey(startColor, 0.0f),
                new GradientColorKey(endColor, 1.0f)
            },
            new GradientAlphaKey[] {
                new GradientAlphaKey(startColor.a, 0.0f),
                new GradientAlphaKey(endColor.a, 1.0f)
            }
        );
        trail.colorGradient = gradient;
    }

    void Update()
    {
        float targetTime = initialDelay + cycleCount * delayBetweenBeats;

        if (!isRunning && BeatManager.GlobalTime >= targetTime)
        {
            StartCoroutine(FollowSpline());
        }
    }

    IEnumerator FollowSpline()
    {
        isRunning = true;
        progress = 0f;

        trail.enabled = false;
        trail.Clear();
        transform.position = splineContainer.EvaluatePosition(0f);
        yield return null;

        trail.enabled = true;
        yield return null;

        progress = 0.0001f;
        transform.position = splineContainer.EvaluatePosition(progress);
        yield return null;

        while (progress < 1f)
        {
            float step = speed * Time.deltaTime;
            float substep = step / substepsPerFrame;

            for (int i = 0; i < substepsPerFrame && progress < 1f; i++)
            {
                progress += substep;
                transform.position = splineContainer.EvaluatePosition(progress);
                yield return null;
            }
        }

        yield return new WaitForSeconds(pauseAtEndDuration + Lifetime);

        cycleCount++;
        isRunning = false;
    }
}