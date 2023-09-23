using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : MonoBehaviour
{
    public GameObject screamer;
    public GameObject tab;
    public GameObject UI;
    public GameObject playerCam;
    public GameObject droneCam;
    public AudioSource screamerSound;
    TabController cameras;
    Animator anim;

    private void Awake()
    {
        anim = screamer.GetComponent<Animator>();
        cameras = UI.GetComponent<TabController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke("End", 1f);
            cameras.Close();
            //Destroy(tab);
            //Destroy(UI);
            tab.SetActive(false);
            UI.SetActive(false);
            gameObject.SetActive(false);
            if (droneCam.activeSelf)
            {
                droneCam.SetActive(false);
                playerCam.SetActive(true);

            }
            screamer.SetActive(true);
            anim.SetBool("Scream", true);
            screamerSound.Play();
        }
    }

    public void End()
    {
        SceneManager.LoadScene("LooseScene");
    }
}
