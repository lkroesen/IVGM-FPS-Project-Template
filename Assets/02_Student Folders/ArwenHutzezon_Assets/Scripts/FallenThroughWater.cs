using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenThroughWater : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health health = other.GetComponent<Health>();
            health.Kill();
        }
    }
}
