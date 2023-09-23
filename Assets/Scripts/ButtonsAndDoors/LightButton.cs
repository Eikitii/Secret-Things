using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightButton : MonoBehaviour
{
    public GameObject doorLight;
    public AudioSource lightSound;
    Vector3 position;
    public Battery energy;

    void Awake()
    {
        position = transform.localPosition;
    }

    private void Update()
    {
        if (energy.energy <= 0)
        {
            doorLight.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        transform.localPosition = position - transform.forward * -0.03f;
        if (energy.energy > 0)
        {
            doorLight.SetActive(true);
            lightSound.Play();
        }

    }

    void OnMouseUp()
    {
        transform.localPosition = position;
        doorLight.SetActive(false);
        lightSound.Pause();
    }
}
