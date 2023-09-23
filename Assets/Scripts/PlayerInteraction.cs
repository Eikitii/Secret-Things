using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public Camera DroneCam;
    public float InteractionDistance;

    public GameObject InteractionUI;
    public TextMeshProUGUI InteractionText;

    void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = DroneCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool HitSomething = false;

        if (Physics.Raycast(ray, out hit, InteractionDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            
            if (interactable != null)
            {
                HitSomething = true;
                InteractionText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }

        }

        InteractionUI.SetActive(HitSomething);
    }
}
