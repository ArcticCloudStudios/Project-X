using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arctic.Keybinds;

public class Devmode : MonoBehaviour
{
    bool devmode;
    KeybindingManager Keybinds;


    public void Start()
    {
        devmode = false;
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(Keybinds._DevMode))
        {
            if (devmode)
            {
                devmode = false;
            } else if (!devmode)
            {
                //TODO: Add Devmode functions
            }
        }
    }
}
