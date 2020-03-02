using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arctic.Keybinds;

public enum InputMode { Keyboard, Gamepad }

public class InputManager : MonoBehaviour
{
    KeybindingManager Keybinds;
    public static InputMode mode = InputMode.Keyboard;
    [HideInInspector]
    public static Vector2 LookAxis = Vector2.zero, MoveAxis = Vector2.zero;

    private void Update()
    {
        LookAxis = new Vector2(UnityEngine.Input.GetAxisRaw("Mouse X"), UnityEngine.Input.GetAxisRaw("Mouse Y"));
        MoveAxis = Vector2.zero;
        if (UnityEngine.Input.GetKey(Keybinds.WalkForward)) MoveAxis.y += 1.0f; print("Hello Im Walking!");
        if (UnityEngine.Input.GetKey(Keybinds.WalkBackward)) MoveAxis.y -= 1.0f;
        if (UnityEngine.Input.GetKey(Keybinds.WalkRight)) MoveAxis.x -= 1.0f;
        if (UnityEngine.Input.GetKey(Keybinds.WalkLeft)) MoveAxis.x += 1.0f;
    }
}
