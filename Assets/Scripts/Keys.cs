
using Fungus;
using TMPro;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [SerializeField] private Collect keys;
     private QuestManager manager;
    [SerializeField] private TextMeshProUGUI UI_Interact;
    [SerializeField] private Flowchart queenKeys;  
    
    private bool isPressed;

    private void Start()
    {
        isPressed = false;
        manager = ServiceLocator.Instance.GetService<QuestManager>();
    }
    private void Update()
    {
       if(isPressed)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.SetActive(false);
                UI_Interact.enabled = false;
                keys.Collected();
                queenKeys.SetIntegerVariable("CurrentKeys",keys.Current);
                manager.setActiveQuest();    
            }
        }
    }

private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.tag == "Player")
    {
        UI_Interact.enabled = true;
        isPressed = true;
    }
}
}
