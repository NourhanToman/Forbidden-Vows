using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Flowchart doorCheck;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
    }

    private void Update()
    {
        if (!doorCheck.GetBooleanVariable("IsQueen"))
        {
                Follow();          
        }
    }

    private void Follow()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
    }
}
