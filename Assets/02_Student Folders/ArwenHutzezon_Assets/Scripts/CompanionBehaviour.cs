using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _rightDistanceFromPlayer = 2;
    [SerializeField] private float _forwardDistanceFromPlayer = 2;

    private Vector3 _targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        _targetPosition = _player.transform.position + _player.transform.right * _rightDistanceFromPlayer + _player.transform.forward * _forwardDistanceFromPlayer + _player.transform.up * 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        _targetPosition = _player.transform.position + _player.transform.right * _rightDistanceFromPlayer + _player.transform.forward * _forwardDistanceFromPlayer + _player.transform.up * 0.75f;
        Debug.Log(_targetPosition);
        transform.position = _targetPosition;
    }
}
