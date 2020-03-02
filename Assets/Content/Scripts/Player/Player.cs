using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSettings settings;
    public float _health; //Current Health
    public float _stamina; //Current Stamina

    [HideInInspector]
    public PlayerMovement movement;
    public PlayerUI PUI;

    public void Start()
    {
        LoadPrefs();
        movement = GetComponent<PlayerMovement>();
        PUI = GetComponent<PlayerUI>();

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
