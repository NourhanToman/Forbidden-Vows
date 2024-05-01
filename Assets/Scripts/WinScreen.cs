using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Flowchart win;
    private void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.tag == "Queen")
        {
            win.ExecuteBlock("WinScreen");
        }
    }
}
