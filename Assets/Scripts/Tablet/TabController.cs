using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
    public GameObject Tablet;
    public Animator anim;
    public object attention;
    public GameObject minimap;
    public GameObject[] cameras;
    public GameObject mainCamera;
    public Battery energy;
    public AudioSource cameraSound;
    public GameObject muteButton;
    public AudioSource phoneGuy;
    private int currentCameraIndex = 0;
    private void Awake()
    {
        anim = Tablet.GetComponent<Animator>();
    }
    private void Update()
    {
        if (energy.energy <= 0)
        {
            Close();
        }
    }
       public void MutePhone()
    {
        muteButton.SetActive(false);
        phoneGuy.Pause();

    }
    public void tabChangeVisible()
    {
        if (minimap.activeSelf || energy.energy <= 0)
        {
            Close();
        }
        else
        {
            StartCoroutine(Open());
        }
    }
    IEnumerator Open()
    {
        anim.SetBool("IsOpen", true);
        yield return new WaitForSeconds(0.4f);
        minimap.SetActive(true);
        mainCamera.SetActive(false);
        cameras[currentCameraIndex].SetActive(true);
    }
    public void Close()
    {
        cameras[currentCameraIndex].SetActive(false);
        mainCamera.SetActive(true);
        minimap.SetActive(false);
        anim.SetBool("IsOpen", false);
    }
    public void ChangeCamera(int index)
    {
        cameras[currentCameraIndex].SetActive(false);
        currentCameraIndex = index;
        cameras[currentCameraIndex].SetActive(true);
        cameraSound.Play();
    }
}
