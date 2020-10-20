using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompanionBehaviour : MonoBehaviour
{
    [Header("Follow positioning")]
    [SerializeField] private GameObject _packLeader;
    [SerializeField] private float _minFollowDistance = 3;

    private NavMeshAgent _agent;
    private Transform _currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    private void Move(Transform target, float minDistance)
    {
        if (Vector3.Distance(transform.position, target.position) > minDistance)
        {
            _agent.SetDestination(target.position);
        }

        else
        {
            _agent.SetDestination(transform.position);
        }
    }

    private void Follow()
    {
        Move(_packLeader.transform, _minFollowDistance);
    }
}
