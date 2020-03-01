using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSettings settings;
    [HideInInspector]
    public PlayerMovement movement;

    public void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        HandleInput();
    }

    public void HandleInput()
    {
        movement.moveAxis = InputManager.MoveAxis;
    }
}
