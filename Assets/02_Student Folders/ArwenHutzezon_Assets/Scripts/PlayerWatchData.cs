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
            if (hit.collider.gameObject.GetComponent<ObjectiveCompanionReachPoint>())
            {
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            }
        }
    }
    public (GameObject, Transform, float) GetRaycast()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            Debug.Log(transform);
            return (hit.collider.gameObject, hit.transform, 0);
        }

        else
        {
            Debug.Log("What even?");
            return (transform.gameObject, transform, 3);
        }
    }

}
