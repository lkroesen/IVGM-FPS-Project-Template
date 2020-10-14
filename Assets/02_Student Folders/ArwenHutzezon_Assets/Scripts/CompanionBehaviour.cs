using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompanionBehaviour : MonoBehaviour
{
    [Header("Follower stats")]
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _rotateSpeed = 5;
    [SerializeField] private float _gravityDownForce = 10;
    
    [Header("Follow positioning")]
    [SerializeField] private GameObject _packLeader;

    [SerializeField] private float _yOffset = 1;
    [SerializeField] private float _minFollowDistance = 3;

    private Transform _target;
    private PlayerCharacterController _playerCharacterController;
    private Vector3 _lookDirection;
    private Vector3 _targetDirection;

    private Vector3 _currentTarget;

    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _target = _packLeader.GetComponent<Transform>();
        _playerCharacterController = _packLeader.GetComponent<PlayerCharacterController>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _currentTarget = _target.position;
        Follow();
    }

    private void Follow()
    {
        if (Vector3.Distance(transform.position, _currentTarget) > _minFollowDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                _currentTarget + new Vector3(0,_yOffset,0),
                _speed * Time.deltaTime);

            _targetDirection = _currentTarget - transform.position;
            _lookDirection = Vector3.RotateTowards(transform.forward, 
                _targetDirection + new Vector3(0, _yOffset, 0),
                _rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(_lookDirection);
        }
    }
}
