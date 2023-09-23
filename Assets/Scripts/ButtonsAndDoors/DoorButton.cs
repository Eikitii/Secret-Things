using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    Vector3 position;
    public Door door;
    public AudioSource doorSound;
    void Awake()
    {
        position = transform.localPosition;
    }

    private void OnMouseDown()
    {
        transform.localPosition = position - transform.forward * -0.03f;
        door.ButtonPressed();
        Invoke("MouseUp", 0.1f);
        doorSound.Play();
    }

    void MouseUp()
    {
        transform.localPosition = position;
    }
}
