using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public float maxFuel;
    public float curFuel;
    public float fuelFallRate;
    public bool isOn;
    Player P;

    public void Start()
    {
        P = GameObject.Find("Player").GetComponent<Player>();

        curFuel = maxFuel;
    }

    public void Update()
    {
        if (isOn)
        {
            curFuel -= Time.deltaTime * fuelFallRate;
        }
        
    }
}
