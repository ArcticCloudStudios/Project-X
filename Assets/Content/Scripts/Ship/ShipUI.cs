using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipUI : MonoBehaviour
{
    public Text Speed;
    ShipStats SS;

    public void Start()
    {
        Speed = GameObject.Find("SpeedText").GetComponent<Text>();
        SS = gameObject.GetComponent<ShipStats>();
    }

    public void Update ()
    {
        int SpeedInt;
       

        Speed.text = SS.curSpeed.ToString("0");
    }
}
