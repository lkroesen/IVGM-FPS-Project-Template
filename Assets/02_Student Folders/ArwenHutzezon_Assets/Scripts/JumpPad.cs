using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float _upwardsForce = 50;
    
    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacterController controller = other.GetComponent<PlayerCharacterController>();
        if (controller && other.CompareTag("Player"))
        {
            controller.SimulateJump(_upwardsForce);
        }
    }
}
