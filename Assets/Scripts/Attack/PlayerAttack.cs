using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Flowchart player;
    [SerializeField] private Collect killGuards;
    private QuestManager manager;
    private bool isAttacking = false;


    //delay
    private bool waiting = false;
    private float waitStartTime;
    private float waitDuration = 4f;
    private void Start()
    {
        manager = ServiceLocator.Instance.GetService<QuestManager>();
    }

    void FixedUpdate()
    {
        
        Attack();
        
    }

    private void Attack()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
                anim.SetTrigger("Attack");
                isAttacking = true;
            
        }
        delay();

    }


    private void delay()
    {
        if (!waiting)
        {

            waiting = true;
            waitStartTime = Time.time;
        }
        else
        {
            float elapsedTime = Time.time - waitStartTime;
            if (elapsedTime >= waitDuration)
            {
                waiting = false;
                isAttacking = false;
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "King" && isAttacking)
        {
            Destroy(other.gameObject);
            
            player.ExecuteBlock("DeadScreen");
        }

        if (other.gameObject.tag == "Brandon" && isAttacking)
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Dead");
            player.ExecuteBlock("OpenBrandonDoor");
        }
        if(other.gameObject.tag == "Guard" && isAttacking)
        {
            other.gameObject.GetComponent<NPCHPSystem>().HP -= 10;
            if (other.gameObject.GetComponent<NPCHPSystem>().HP <= 0)
            {
                Destroy(other.gameObject, 5f);
                other.gameObject.GetComponent<Animator>().SetTrigger("Dead");
                other.gameObject.GetComponent<NPCHPSystem>().HPpanel.SetActive(false);
                other.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                killGuards.Collected();
                if (!killGuards.isOngoing)
                {
                    manager.setActiveQuest();
                }
                
            }
        }
    }

}
