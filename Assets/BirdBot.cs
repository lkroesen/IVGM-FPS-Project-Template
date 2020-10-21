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

    private Transform _target;

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
        
        else if (_birdState == BirdState.Targeted)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position,
                Time.deltaTime * _speed);
            transform.LookAt(new Vector3(_target.position.x, transform.position.y, _target.position.z));
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
        
        transform.LookAt(new Vector3(_player.position.x, transform.position.y, _player.position.z));
    }

    void Point()
    {
        (GameObject hit, Transform potentialTarget, float distance) = _watchData.GetRaycast();
        Debug.Log("Potential target: " + potentialTarget);
        ObjectiveCompanionReachPoint _objective = hit.GetComponent<ObjectiveCompanionReachPoint>();
        if (_objective && potentialTarget.position.y > _minHeight)
        {
            Debug.Log(string.Format("Destination: {0}", potentialTarget.position));
            _target = potentialTarget;
        }

        else
        {
            Debug.Log("No prey");
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
                Point();
            }

            else
            {
                _birdState = BirdState.Follow;
            }
        }
    }

    public void SetStateToFollow()
    {
        _birdState = BirdState.Follow;
    }
}
