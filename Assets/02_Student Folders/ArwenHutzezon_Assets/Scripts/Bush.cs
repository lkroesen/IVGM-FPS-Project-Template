using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CompanionBehaviour>())
        {
            Destroy(gameObject);
        }
    }
}
