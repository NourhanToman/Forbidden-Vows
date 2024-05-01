using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnd : MonoBehaviour
{
    [SerializeField] private Flowchart end;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            end.ExecuteBlock("DeadScreen");
        }
        
    }
}
