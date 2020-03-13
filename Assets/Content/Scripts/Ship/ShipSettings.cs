using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShipSettings", menuName = "Ship/ShipSettings")]
public class ShipSettings : ScriptableObject
{
    [Header("Health")]
    public float ShipMaxHealth;

    [Header("Speed")]
    public float maxSpeed;

    [Header("Weight")]
    public float ShipWeight;
    
}
