using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    private int time = 0;
    private TMP_Text clock;

    private void Awake()
    {
        clock = gameObject.GetComponent<TMP_Text>();
        InvokeRepeating("Timer", 60f, 60f);
    }

    public void Timer()
    {
        time++;

        clock.text = time.ToString() + " AM";


        if (time >= 6)
        {
            CancelInvoke();
            SceneManager.LoadScene("FinalScene");
        }
    }
}
