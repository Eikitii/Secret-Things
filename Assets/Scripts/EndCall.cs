using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class EndCall : MonoBehaviour
{
    public AudioSource phoneGuy;
    public GameObject muteButton;

    public void EndPhoneCall()
    {
        phoneGuy.Stop();
    }
}
