using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubjectInteract : MonoBehaviour
{
    [SerializeField] private LayerMask Interact_Layer;
    [SerializeField] private TextMeshProUGUI UI_Interact;

    private Interactable Current_Object;

    void Start()
    {
        UI_Interact.enabled = false;
    }
 
    void Update()
    {
        if (Current_Object != null)
        {
            Current_Object.interact();

            if (Input.GetKeyDown(KeyCode.E))
            {
                Current_Object.IsFired = true;
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                Current_Object.IsFired = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(Interact_Layer == (Interact_Layer | (1 << other.gameObject.layer)))
        {
                        
            if (other.TryGetComponent<Interactable>(out var interactable) && other.GetComponent<Interactable>().isOngoing)
            {
                UI_Interact.enabled = true;
                Current_Object = interactable;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer != Interact_Layer)
        {
            UI_Interact.enabled= false;
            Current_Object = null;
        }
    }


}
