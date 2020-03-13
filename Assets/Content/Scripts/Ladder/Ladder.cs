using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arctic.Keybinds;

public class Ladder : MonoBehaviour
{
    KeybindingManager key;

    public GameObject Player;
    public bool canClimb;
    public bool PlayerPressed;
    public float ClimbSpeed;

    public void Start()
    {
        Player = GameObject.Find("Player");
        key = GameObject.Find("InputManager").GetComponent<KeybindingManager>();
    }

    public void Update()
    {
        if (PlayerPressed)
        {
            if (canClimb)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    
                    Player.transform.Translate(Vector3.up * Time.deltaTime * ClimbSpeed);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    Player.transform.Translate(Vector3.down * Time.deltaTime * ClimbSpeed);
                }
            }

            if (Input.GetKeyDown(key.Interact))
            {

            }
        }
    }

}
