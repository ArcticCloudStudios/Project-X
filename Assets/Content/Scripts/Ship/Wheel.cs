using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arctic.Keybinds;

public class Wheel : MonoBehaviour
{
    KeybindingManager key;
    Engine en;

    [Header("Rotations")]
    public float turnSpeed;
    public float shipturnSpeed;
    public float shipturnSpeedInc;
    public int curRotationRight;
    public int curRotationLeft;
    public int maxRotations;
    public int degree;
    public float d;

    [Header("GameObjects")]
    public GameObject Ship;
    public GameObject ForwardPoint;
    public GameObject WheelCam;

    [Header("Use")]
    public bool isPlayerUsing;

    public bool isTurningright;
    public bool isTurningleft;

    public void Start()
    {
        key = GameObject.Find("InputManager").GetComponent<KeybindingManager>();
        en = GameObject.Find("Engine").GetComponent<Engine>();

    }

    public void FixedUpdate()
    {
        if (isPlayerUsing)
        {
            Control();
        }
    }

    public void Update()
    {
        if (degree >= 14250)
        {
            degree = 14250;
        }



        if (isTurningright && !isTurningleft)
        {
            Ship.transform.Rotate(Vector3.up * (shipturnSpeed * Time.deltaTime));
        }
        if (isTurningleft && !isTurningright)
        {
            Ship.transform.Rotate(Vector3.down * (shipturnSpeed * Time.deltaTime));
        }
    }

    public void Control()
    {
        //When Wheel is rotating right on z axis
        if (Input.GetKey(key.WalkRight) && en.isOn && curRotationRight < 3)
        {
            if (isTurningleft && shipturnSpeed > 0)
            {
                transform.Rotate(Vector3.forward * (turnSpeed * Time.deltaTime));
                Debug.Log(this.transform.eulerAngles.z);
                shipturnSpeed -= Time.deltaTime * shipturnSpeedInc;

            }
            else
            {
                isTurningleft = false;
                isTurningright = true;
                transform.Rotate(Vector3.forward * (turnSpeed * Time.deltaTime));
                Debug.Log(this.transform.eulerAngles.z);
                shipturnSpeed += Time.deltaTime * shipturnSpeedInc;

                /*if (this.transform.eulerAngles.z == 359)
                {
                    curRotationRight++;
                }*/


            }
        }
        //When Wheel is rotating left on z axis
        if (Input.GetKey(key.WalkLeft) && en.isOn)
        {
            if (isTurningright && shipturnSpeed > 0)
            {
                transform.Rotate(Vector3.back * (turnSpeed * Time.deltaTime));
                shipturnSpeed -= Time.deltaTime * shipturnSpeedInc;
                
            }
            else
            {
                isTurningright = false;
                isTurningleft = true;
                transform.Rotate(Vector3.back * (turnSpeed * Time.deltaTime));
                shipturnSpeed += Time.deltaTime * shipturnSpeedInc;

            }
        }

    }     
}

