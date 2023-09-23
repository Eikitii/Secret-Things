using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPoints : MonoBehaviour
{
    public Transform[] NextCheckPoints;
    public int id;
    int Chance;

    private void Awake()
    {
        StartChance();
    }

    void StartChance()
    {
        EnemyController.toPlayerChance = 80;
        Chance = EnemyController.toPlayerChance;
    }

    void SetChance()
    {
        if (id == 1)
        {
            EnemyController.toPlayerChance = 100;
        }
        else if (id == 5 | id == 6)
        {
            EnemyController.toPlayerChance = 0;
        }
    }

    public Transform getNext()
    {
        SetChance();
        Chance = EnemyController.toPlayerChance;
        int rand = Random.Range(1, 100);
        if (rand <= Chance)
        {
            if (NextCheckPoints.Length > 1)
            {
                return NextCheckPoints[Random.Range(1, NextCheckPoints.Length)];
            }
            else
            {
                return NextCheckPoints[0];
            }
        }
        else
        {
            return NextCheckPoints[0];
        }
    }
}
