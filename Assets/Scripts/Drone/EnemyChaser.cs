using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyChaser : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Player1;
    public GameObject Camera2;
    public GameObject Player2;
    public Behaviour canvas;
    private bool isPlayered;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            canvas.enabled = !canvas.enabled;
            Cursor.lockState = CursorLockMode.Locked;
            if (isPlayered == false)
            {
                Camera2.SetActive(true);
                Player2.GetComponent<FirstPersonMovement>().enabled = true;

                Camera1.SetActive(false);
                isPlayered = true;               
            }
            else
            {
                Camera2.SetActive(false);
                Player2.GetComponent<FirstPersonMovement>().enabled = false;
                Camera1.SetActive(true);
                isPlayered = false;
            }
        }
    }
}