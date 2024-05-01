using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable", menuName = "Collect")]
public class Collect : Objective
{

    public int Target;
    public int Current;

    private void OnEnable()
    {
        isOngoing = true;
        Current = 0;
    }

    public void Collected()
    {
        if (Current < Target)
        {
            Current++;
        }
        
        if (Current >= Target)
        {
            isOngoing = false;
        }
    }
}
