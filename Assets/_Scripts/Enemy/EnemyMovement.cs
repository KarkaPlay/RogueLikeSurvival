using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private NavMeshAgent _agent;

    private void Start()
    {
        _agent = transform.GetComponent<NavMeshAgent>();
        player = PlayerStore.Player.transform;
    }

    private void Update()
    {
        _agent.SetDestination(player.position);
    }
}