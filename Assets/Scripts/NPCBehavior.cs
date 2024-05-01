
using Fungus;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehavior : MonoBehaviour
{
    public Transform referencePlane; 
    public float roamRadius = 10f;
    public float meleeRange = 2f;
    public float roamTimer = 5f;

    [SerializeField] private Transform player;
    [SerializeField] private Flowchart isAlert;
    bool isAlertActive;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private NPCHPSystem nPCHPSystem;
    private float timer;


    //delay
    private bool waiting = false;
    private float waitStartTime;
    private float waitDuration = 1.5f;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();    
        nPCHPSystem = GetComponent<NPCHPSystem>();
        isAlertActive = isAlert.GetBooleanVariable("IsAlert");

        Roam();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= roamTimer)
        {
            Roam();
            timer = 0;
        }

        delay();
        isAlertActive = isAlert.GetBooleanVariable("IsAlert");


        if (Vector3.Distance(transform.position, player.position) <= meleeRange && !waiting && nPCHPSystem.HP>0 && isAlertActive)
        {
            
            MeleeAttack();
        }
        
    }

    private void Roam()
    {
       
        Vector3 randomDirection = Random.insideUnitCircle * roamRadius;
        Vector3 randomPosition = referencePlane.position + referencePlane.right * randomDirection.x +
                                 referencePlane.forward * randomDirection.y;

        randomPosition.y = referencePlane.position.y;
        randomPosition.y = referencePlane.position.y; 

        navMeshAgent.SetDestination(randomPosition);
    }

    private void MeleeAttack()
    {
        transform.LookAt(player.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        animator.SetTrigger("Attack");
        navMeshAgent.SetDestination(player.position);

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
            }
        }
    }
}
