using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompanionBehaviour : MonoBehaviour
{
    [Header("Follow positioning")]
    [SerializeField] private GameObject _packLeader;
    [SerializeField] private float _minFollowDistance = 3;

    private float _currentMinDistance;

    private NavMeshAgent _agent;
    private Transform _currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Follow();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, _currentTarget.position) > _currentMinDistance)
        {
            _agent.SetDestination(_currentTarget.position);
        }

        else
        {
            _agent.SetDestination(transform.position);
        }
    }

    private void Follow()
    {
        _currentTarget = _packLeader.transform;
        _currentMinDistance = _minFollowDistance;
    }
}
