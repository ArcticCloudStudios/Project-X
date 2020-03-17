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
    public GameObject Barrel;

    [Header("Stats")]
    public bool CannonLoaded;
    public int CannonInBarrel;
    public float cannonForce;
    public float ReloadTime;

    [Header("UI")]
    public Text Number;
    GameObject Canvas;
    public Slider ReloadSlider;

    GameObject WeaponCanvas;

    bool playerOn;
    bool PlayerUsing;
    bool IsReloading;

    public void Start()
    {
        PUI = GameObject.Find("Player").GetComponent<PlayerUI>();
        Canvas = Number.transform.parent.gameObject;
        WeaponCanvas = GameObject.Find("WeaponUI");
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
        Number.text = CannonInBarrel.ToString();
        
        if (CannonInBarrel == 1)
        {
            CannonLoaded = true;
        } else if (CannonInBarrel == 0)
        {
            CannonLoaded = false;
        }

        if (PlayerUsing)
        {
            WeaponCanvas.SetActive(false);
            PUI.InteractTextObj.SetActive(false);
            Barrel.transform.parent = PlayerCamera.transform;
            Canvas.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Mouse0) && CannonLoaded)
            {
                Debug.Log("hello!");
                GameObject Ball = Instantiate(CannonProjectile, ShootPoint.transform.position, Quaternion.identity);
                Rigidbody RB = Ball.GetComponent<Rigidbody>();
                RB.AddForce(ShootPoint.transform.forward * cannonForce, ForceMode.Impulse);
                CannonInBarrel = 0;
            }
            if (Input.GetKeyDown(KeyCode.R) && !CannonLoaded) //TODO: Change to Arctic.KeyBind key TODO: Check Player Inventory for CannonBalls
            {
                IsReloading = true;
            }
        }

        if (playerOn)
        {
            if (Input.GetKeyDown(Key.Interact) && !PlayerUsing)
            {
                PlayerUsing = true;
                P.cam.SetActive(false);
                PlayerCamera.SetActive(true);
               
            }
            if (Input.GetKeyDown(KeyCode.Escape) && PlayerUsing)
            {
                PlayerUsing = false;
                P.cam.SetActive(true);
                P.gameObject.transform.position = PlayerCamera.gameObject.transform.position;
                PlayerCamera.SetActive(false);
              
            }
        }
        if (!PlayerUsing)
        {
            Canvas.SetActive(false);
            WeaponCanvas.SetActive(true);
            Barrel.transform.parent = gameObject.transform;
        }
        if (IsReloading)
        {
            ReloadSlider.gameObject.SetActive(true);
            ReloadSlider.value += ReloadTime * Time.deltaTime;
            if (ReloadSlider.value >= ReloadSlider.maxValue)
            {
                ReloadSlider.gameObject.SetActive(false);
                CannonInBarrel = 1;
                ReloadSlider.value = 0;
                IsReloading = false;
            }
        
        }
        
    }

    


}
