using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundBrandon : MonoBehaviour
{
    [SerializeField] private Flowchart brandon;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            brandon.ExecuteBlock("FoundBrandon");

        }
    }

    
}
