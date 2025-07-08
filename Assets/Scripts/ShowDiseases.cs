using UnityEngine;

public class ShowDiseases : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;
    public GameObject[] objectsToShow;
    public GameObject[] objectsToHide;

    // Call this from a single button
    public void Diseases()
    {
        // Activate objects
        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null)
                obj.SetActive(true);
        }

        // Deactivate objects
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        // Show objects (enable their renderers)
        foreach (GameObject obj in objectsToShow)
        {
            if (obj != null)
            {
                Renderer rend = obj.GetComponent<Renderer>();
                if (rend != null)
                    rend.enabled = true;
            }
        }

        // Hide objects (disable their renderers)
        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null)
            {
                Renderer rend = obj.GetComponent<Renderer>();
                if (rend != null)
                    rend.enabled = false;
            }
        }
    }
}
