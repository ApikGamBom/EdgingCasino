using UnityEngine;

public class interactable : MonoBehaviour
{
    public LayerMask interactableMask;
    public bool lookingAtInteractable;
    public Camera cam;
    public float interactableDistance = 3f;

    int frameCount = 0;

    void Update()
    {
        frameCount++;
        if (frameCount % 10 == 0) // Change 10 to a higher number to reduce frequency further
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, interactableDistance, interactableMask))
            {
                lookingAtInteractable = true;
            }
            else
            {
                lookingAtInteractable = false;
            }
        }
    }
}