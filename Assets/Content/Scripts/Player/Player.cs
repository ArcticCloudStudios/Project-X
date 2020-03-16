using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arctic.Keybinds;

public class Player : MonoBehaviour
{
    public PlayerSettings settings;
    public KeybindingManager Key;
    public PlayerUI PUI;
    MouseLook ML;
    [HideInInspector]
    public GameObject cam;

    [Header("Vitals")]
    public float _health; //Current Health
    public float _stamina; //Current Stamina

    [HideInInspector]
    public PlayerMovement movement;
    [HideInInspector]
    Wheel W;
    [HideInInspector]
    bool IsTriggered;
    bool IsEngine;
    [HideInInspector]
    public bool InUse;

    public void Start()
    {
        LoadPrefs();
        Key = GameObject.Find("InputManager").GetComponent<KeybindingManager>();
        movement = GetComponent<PlayerMovement>();
        PUI = GetComponent<PlayerUI>();
        cam = GameObject.Find("Main Camera");
        ML = cam.GetComponent<MouseLook>();

        PUI.HealthSlider.maxValue = settings.MaxHealth;
        PUI.HealthSlider.value = _health;
        PUI.StaminaSlider.maxValue = settings.MaxStamina;
        PUI.StaminaSlider.value = _stamina;
    }

    public void Update()
    {
        PUI.HealthSlider.value = _health;
        PUI.StaminaSlider.value = _stamina;
        SavePrefs();
        //WHEEL
        UseWheel();
        ExitWheel();
        TurnOnEngine();

        //STAMINA
        if (movement.Sprinting)
        {
            _stamina -= settings.StaminaFallRate * Time.deltaTime;
        } else
        {
            _stamina += settings.StaminaRegenRate * Time.deltaTime;
        }
        if (_stamina <= 0)
        {
            movement.Sprinting = false;
            _stamina = 0;
        }
        if (_stamina >= settings.MaxStamina)
        {
            movement.Sprinting = false;
            _stamina = settings.MaxStamina;
        }

      
    }

    public void UseWheel()
    {
        if (Input.GetKeyDown(Key.Interact) && IsTriggered && !InUse)
        {
            InUse = true;
            movement.canMove = false;
            cam.SetActive(false);
            W.WheelCam.SetActive(true);
            W.isPlayerUsing = true;
            PUI.InteractTextObj.SetActive(false);

            transform.rotation = W.ForwardPoint.transform.rotation;
            transform.position = W.ForwardPoint.transform.position;
            cam.transform.rotation = W.ForwardPoint.transform.rotation;
        }
    }

    public void ExitWheel()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsTriggered && InUse)
        {
            InUse = false;
            movement.canMove = true;
            W.isPlayerUsing = false;
            cam.SetActive(true);
            W.WheelCam.SetActive(false);
            transform.rotation = W.ForwardPoint.transform.rotation;
            transform.position = W.ForwardPoint.transform.position;

        }
    }

    public void TurnOnEngine()
    {
        if (Input.GetKeyDown(Key.Interact) && IsEngine)
        {
            Engine en = GameObject.Find("Engine").GetComponent<Engine>();
            en.isOn = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        PUI.InteractTextObj.SetActive(true);

        if (other.gameObject.tag == "Wheel")
        {
            IsTriggered = true;
            W = other.gameObject.GetComponent<Wheel>();
            PUI.InteractText.text = "Press " + Key.Interact.ToString() + " To Use";

        }

        if (other.gameObject.tag == "Ladder")
        {
            Ladder Ladder = other.gameObject.GetComponent<Ladder>();
            PUI.InteractText.text = "Press " + Key.Interact.ToString() + " To Climb";
            Ladder.PlayerPressed = true;
            Ladder.canClimb = true;
        }

        if (other.gameObject.tag == "Engine")
        {
            IsEngine = true;
            Engine en = GameObject.Find("Engine").GetComponent<Engine>();
            
            PUI.InteractText.text = "Press " + Key.Interact.ToString() + " To Turn On";
        }

        if (other.gameObject.tag == "Ship")
        {
            this.transform.parent = other.gameObject.transform;
        }
    }
    

    public void OnTriggerExit(Collider other)
    {
        Ladder Ladder = other.gameObject.GetComponent<Ladder>();
        if (other.gameObject.tag == "Ladder")
        {
            Ladder.PlayerPressed = false;
        }
        PUI.InteractTextObj.SetActive(false);
        PUI.InteractText.text = "";
        if (other.transform.transform.tag == "Ship")
        {
            transform.parent = null;
        }
      
        IsTriggered = false;
    }

     public void LoadPrefs()
     {
         _health = PlayerPrefs.GetFloat("health", settings.MaxHealth);
         _stamina = PlayerPrefs.GetFloat("stamina", settings.MaxStamina);
     }

     public void SavePrefs()
     {
         PlayerPrefs.SetFloat("health", _health);
         PlayerPrefs.SetFloat("stamina", _stamina);
         PlayerPrefs.Save();
     }


 }

