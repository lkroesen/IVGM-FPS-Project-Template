using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;

public enum PetState
{
    Follow,
    Targeted
}
public class CompanionBehaviour : MonoBehaviour
{
    [Header("Follow positioning")]
    [SerializeField] private GameObject _packLeader;

    [SerializeField] private GameObject _camera;
    [SerializeField] private float _minFollowDistance = 3;

    private float _interactionDistance;

    private PetState _petState;
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
        MicroInputManager();
        if (_petState == PetState.Follow)
        {
            Move(_packLeader.transform, _minFollowDistance);
        }
        
        else if (_petState == PetState.Targeted)
        { 
            Move(_currentTarget, _interactionDistance);
        }
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

    public void Follow()
    {
        _petState = PetState.Follow;
    }

    private void Point()
    {
        _petState = PetState.Targeted;
        PlayerWatchData playerWatchData = _camera.GetComponent<PlayerWatchData>();
        if (playerWatchData)
        {
            (GameObject hit, Transform potentialTarget, float touchDistance) = playerWatchData.GetRaycast();
            if (hit.GetComponent<ObjectiveCompanionReachPoint>())
            {
                Debug.Log(hit.transform);
                _currentTarget = potentialTarget;
                _interactionDistance = touchDistance;
                Move(potentialTarget, touchDistance);
                return;
            }

            else
            {
                Debug.Log(string.Format("Hit missed. Reason: {0} {1} {2}", hit, hit.GetComponent<ObjectiveCompanionReachPoint>(), potentialTarget));
                _petState = PetState.Follow;
                return;
            }
        }

        else
        {
            _petState = PetState.Follow;
            return;
        }
    }

    private void MicroInputManager()
    {
        if (Input.GetButtonDown("Ability") && _packLeader.CompareTag("Player"))
        {
            if (_petState == PetState.Follow)
            {
                Point();
            }
            
            else if (_petState == PetState.Targeted)
            {
                Follow();
            }
        }
    }

    public GameObject GetPackLeader()
    {
        return _packLeader;
    }
}
