using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformatorLightSwitch : MonoBehaviour, Interactable
{
    public float TransEnergy = 100f;
    public float TransEnergyDischarge = 10f;
    public Light transformator;
    public GameObject attention;
    public Light bulb1;
    public Light bulb2;
    public Light bulb3;
    public Light bulb4;
    public Light bulb5;
    public Light bulb6;
    public Light bulb7;
    public Light bulb8;
    public Light bulb9;
    public bool IsOn;
    void Start()
    {
        transformator.enabled = IsOn;
        bulb1.enabled = IsOn;
        bulb2.enabled = IsOn;
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
        TurnOff();
    }

    private void TurnOff()
    {
        bulb1.enabled = IsOn;
        bulb2.enabled = IsOn;
        bulb3.enabled = IsOn;
        bulb4.enabled = IsOn;
        bulb5.enabled = IsOn;
        bulb6.enabled = IsOn;
        bulb7.enabled = IsOn;
        bulb8.enabled = IsOn;
        bulb9.enabled = IsOn;


        if (TransEnergy <= 50f && TransEnergy != 0)
        {
            attention.SetActive(true);
            transformator.enabled = IsOn;
            
            //IsOn =false;
        }
        else
        {
            attention.SetActive(false);

            if (TransEnergy == 0)
            {
                IsOn = false;
                transformator.enabled = IsOn;
                bulb1.enabled = IsOn;
                bulb2.enabled = IsOn;
                bulb3.enabled = IsOn;
                bulb4.enabled = IsOn;
                bulb1.enabled = IsOn;
                bulb2.enabled = IsOn;
                bulb3.enabled = IsOn;
                bulb4.enabled = IsOn;
                bulb5.enabled = IsOn;
                bulb6.enabled = IsOn;
                bulb7.enabled = IsOn;
                bulb8.enabled = IsOn;
                bulb9.enabled = IsOn;
            }

        }
    }
    public string GetDescription()
    {
        if (IsOn == true)
        {
            return "Световой трансформатор ещё работает";

        }
        else
        {
            return "Нажмите Е, чтобы включить световой трансформатор";
        }

    }

    public void Interact()
    {
        IsOn = !IsOn;
        transformator.enabled = IsOn;
        TransEnergy = 100f;
    }
}
