using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public static float GlobalTime { get; private set; }

    void Update()
    {
        GlobalTime += Time.deltaTime;
    }

    // Esta función reinicia el tiempo global
    public static void ResetTime()
    {
        GlobalTime = 0f;
    }
}
