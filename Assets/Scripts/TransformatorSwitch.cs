using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformatorSwitch : MonoBehaviour, Interactable
{
    public float TransEnergy=100f;
    public float TransEnergyDischarge = 10f;
    public Light transformator;
    public GameObject attention;
    public GameObject door;
    public GameObject RightDoor;
    public AudioSource sirenSound;
    public bool IsOn;
    void Start()
    {
        transformator.enabled = IsOn;
    }

    private void Awake()
    {
        InvokeRepeating("Discharge", 60f, 15f);
    }

    private void Discharge()
    {
        TransEnergy -= TransEnergyDischarge;
    }

    private void Update()
    {
        OpenDoor();
    }  
    private void OpenDoor()
    {
        sirenSound.Pause();
        if (TransEnergy <= 30f && TransEnergy != 0)
        {
            sirenSound.UnPause();
            attention.SetActive(true);
            transformator.enabled = IsOn;
            //IsOn =false;
        }
        else
        {
            sirenSound.Pause();
            attention.SetActive(false);

            if (TransEnergy == 0)
            {
                IsOn = false;
                transformator.enabled = IsOn;
                door.SetActive(false);
                RightDoor.SetActive(false) ;
            }         
        }     
    }
    public string GetDescription()
    {
        if (IsOn==true)
        {
            return "Удерживающий трансформатор ещё работает";
            
        }
        else
        {
            return "Нажмите Е, чтобы включить удерживающий трансформатор";
        }       
    }
    public void Interact()
    {
        IsOn =!IsOn;
        transformator.enabled = IsOn;
        TransEnergy = 100f;
    }
}
