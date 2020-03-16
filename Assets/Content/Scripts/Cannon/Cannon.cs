using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Arctic.Keybinds;

public class Cannon : MonoBehaviour
{
    KeybindingManager Key;
    Player P;
    PlayerUI PUI;

    [Header("Objects")]
    public GameObject CannonProjectile;
    public GameObject PlayerCamera;
    GameObject Player;
    public GameObject ShootPoint;

    [Header("Stats")]
    public float cannonForce;

    bool playerOn;
    public bool PlayerUsing;

    public void Start()
    {
        PUI = GameObject.Find("Player").GetComponent<PlayerUI>();

        ShootPoint = GameObject.Find("ShootPoint");
        Key = GameObject.Find("InputManager").GetComponent<KeybindingManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player = other.gameObject;
            P = Player.gameObject.GetComponent<Player>();
            playerOn = true;

            PUI.InteractTextObj.SetActive(true);
            PUI.InteractText.text = "Press " + Key.Interact.ToString() + " To Use Cannon";
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOn = false;
            PUI.InteractTextObj.SetActive(false);
        }
    }

    public void Update()
    {
        if (PlayerUsing)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Debug.Log("hello!");
                GameObject Ball = Instantiate(CannonProjectile, ShootPoint.transform.position, Quaternion.identity);
                Rigidbody RB = Ball.GetComponent<Rigidbody>();
                RB.AddForce(ShootPoint.transform.forward * cannonForce, ForceMode.Impulse);
            }
        }

        if (playerOn)
        {
            if (Input.GetKeyDown(Key.Interact) && !PlayerUsing)
            {
                PlayerUsing = true;
                P.cam.SetActive(false);
                PlayerCamera.SetActive(true);
                Shoot();
            }
            if (Input.GetKeyDown(KeyCode.Escape) && PlayerUsing)
            {
                PlayerUsing = false;
                P.cam.SetActive(true);
                P.gameObject.transform.position = PlayerCamera.gameObject.transform.position;
                PlayerCamera.SetActive(false);
              
            }
        }
    }

    public void Shoot()
    {
        
    }


}
