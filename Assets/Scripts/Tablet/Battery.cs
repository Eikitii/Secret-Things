using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public float energy = 100;
    public float discharge = 0.2f;
    public float drone = 0; 

    public GameObject[] segments;
    public TabController tablet;
    public Door door1;
    public Door door2;
    public LightButton light1;
    public LightButton light2;
    public GameObject droneCam;
    

    private void Awake()
    {
        InvokeRepeating("Discharging", 1f, 1f);
    }
    private void Update()
    {
        SetDischarge();
        ViewEnergy();
    }

    private void Discharging()
    {
        energy -= discharge;
    }

    private void ViewEnergy()
    {
        if (energy < 75)
            segments[3].SetActive(false);
        if (energy < 50)
            segments[2].SetActive(false);
        if (energy < 25)
            segments[1].SetActive(false);
        if (energy < 0)
            segments[0].SetActive(false);
    }
    private void SetDischarge()
    {
        float tabletDC;
        float doorsDC;
        float lightDC;

        //разр€дка от планшета
        if (tablet.minimap.activeSelf)
            tabletDC = 0.1f;
        else
            tabletDC = 0f;

        //разр€дка от дверей
        if (door1.isOpen == false && door2.isOpen == false)
            doorsDC = 0.2f;
        else if (door1.isOpen == false && door2.isOpen == true)
            doorsDC = 0.1f;
        else if (door1.isOpen == true && door2.isOpen == false)
            doorsDC = 0.1f;
        else
            doorsDC = 0f;

        //разр€дка от света
        if (light1.doorLight.activeSelf == true || light2.doorLight.activeSelf == true)
            lightDC = 0.1f;
        else
            lightDC = 0f;

        //разр€дка от дрона
        if (droneCam.activeSelf)
        {
            discharge = 0.3f;
        }
        else
        {
            drone = 0.2f;
        }
        //суммарный разр€д
        discharge = 0.2f + tabletDC + doorsDC + lightDC;
    }
}
