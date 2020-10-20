using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenThroughWater : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health)
        {
            health.Kill();
        }
    }
}
