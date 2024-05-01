using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool IsFired;

    [SerializeField] public UnityEvent OnInteract;
    public bool isOngoing = true;

 
    public void interact()
    {
        if (IsFired && isOngoing)
        {
            OnInteract?.Invoke();
            IsFired = false;
            isOngoing = false;
        }
    }
}
