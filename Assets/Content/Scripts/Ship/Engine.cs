using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public bool isOn;
    Player P;

    public void Start()
    {
        P = GameObject.Find("Player").GetComponent<Player>();
    }

    public void Update()
    {
        
    }
}
