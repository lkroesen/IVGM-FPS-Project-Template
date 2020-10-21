using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BirdState
{
    Follow,
    Targeted
}

public class BirdBot : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _followDistance;
    [SerializeField] private float _minFlightHeight;
    [SerializeField] private PlayerWatchData _watchData;

    private BirdState _birdState;

    private void Start()
    {
        _birdState = BirdState.Follow;
    }

    // Update is called once per frame
    void Update()
    {
        MicroInputManager();
        if (_birdState == BirdState.Follow)
        {
            Follow();
        }

        else
        {
            Point();
        }
    }

    void Follow()
    {
        if (_player.position.y > _minHeight && Vector3.Distance(transform.position, _player.position) >= _followDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                new Vector3(_player.position.x, _player.position.y + _followDistance * .5f, _player.position.z), 
                Time.deltaTime * _speed);
        }
        
        else if (_player.position.y < _minHeight)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_player.position.x, _minFlightHeight, _player.position.z),
                Time.deltaTime * _speed);
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position, Time.deltaTime * _speed);
        }
    }

    void Point()
    {
        (GameObject hitCollider, Transform colliderTransform, float distance) = _watchData.GetRaycast();
        ObjectiveCompanionReachPoint _objective = hitCollider.GetComponent<ObjectiveCompanionReachPoint>();
        if (_objective && colliderTransform.position.y > _minHeight)
        {
            Debug.Log("Destination: " + colliderTransform.position);
            transform.position = Vector3.MoveTowards(transform.position, colliderTransform.position,
                Time.deltaTime * _speed);
        }

        else
        {
            _birdState = BirdState.Follow;
        }
    }

    private void MicroInputManager()
    {
        if (Input.GetButtonDown("Ability"))
        {
            if (_birdState == BirdState.Follow)
            {
                _birdState = BirdState.Targeted;
            }

            else
            {
                _birdState = BirdState.Follow;
            }
        }
    }
}
