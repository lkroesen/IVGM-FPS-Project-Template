using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWatchData : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance);
        }
    }
    public (GameObject, Transform, float) GetRaycast()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            return (hit.collider.gameObject, hit.transform, 0);
        }

        else
        {
            return (hit.collider.gameObject, transform, 3);
        }
    }

}
