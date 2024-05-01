using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Scriptable", menuName = "NPC")]
public class NPC : Objective
{
    private void OnEnable()
    {
        isOngoing = true; 
    }

    public void Talk()
    {
        isOngoing = false;
    }
}
