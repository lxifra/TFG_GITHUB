using UnityEngine;

public class ForceBehind : MonoBehaviour
{
    void Start()
    {
        // Force the objects to be render later
        GetComponent<Renderer>().material.renderQueue = 1999;
    }
}