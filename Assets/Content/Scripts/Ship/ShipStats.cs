using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats : MonoBehaviour
{
    public ShipSettings SS;
    public Wheel W;
    public Player P;
    public Engine En;

    [Header("Vitals")]
    public float CurHealth;
    public bool isDamaged;
    public bool isMaxDamaged;

    [Header("Speed")]
    public float curSpeed;
    public float speedInc;
    public bool isStalling;

    public void Start()
    {
        W = GameObject.Find("Wheel").GetComponent<Wheel>();
        P = GameObject.Find("Player").GetComponent<Player>();
        En = GameObject.Find("Engine").GetComponent<Engine>();

        CurHealth = SS.ShipMaxHealth;
        
    }

    public void Update()
    {
        MoveShip();
    }

    

    public void MoveShip ()
    {
        

        if (En.isOn)
        {
            if (curSpeed <= SS.maxSpeed)
            {
                curSpeed += Time.deltaTime * speedInc;
            }
       
            if (curSpeed >= SS.maxSpeed)
            {
                curSpeed = SS.maxSpeed;
            }
            gameObject.transform.position += (transform.forward * -0.1f) * Time.deltaTime * curSpeed;
           
        }
    }
}
