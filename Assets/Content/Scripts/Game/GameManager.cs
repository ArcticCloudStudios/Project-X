using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Information")]
    public int PlayerLevel = 0;

    [HideInInspector]
    public float curPlayerXp = 0.0f;
    [HideInInspector]
    public float neededPlayerXp = 142.5f;

    public int PlayerCurrency = 0;


    void SetNextLevelXpRequirement()
    {
        neededPlayerXp = neededPlayerXp + neededPlayerXp * 2;
    }
}
