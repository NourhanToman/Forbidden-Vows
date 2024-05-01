using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttack : MonoBehaviour
{
    private QuestManager manager;
    [SerializeField] private Flowchart deadPlayer;
    void Start()
    {
        manager = ServiceLocator.Instance.GetService<QuestManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (manager.HP > 0)
            {
                manager.HP = manager.HP - 10;
            }
            else
            {
                other.gameObject.GetComponent<Animator>().SetTrigger("Dead");
                deadPlayer.ExecuteBlock("DeathScreen");
            }
        }
    }
}
