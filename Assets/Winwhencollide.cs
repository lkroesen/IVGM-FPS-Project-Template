using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winwhencollide : MonoBehaviour
{
    public ObjectiveManager WinLevel;

    Collider triggerZone;

    // Start is called before the first frame update
    void Start()
    {
        triggerZone = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnTriggerEnter(Collider other)
    {
       
    }      
}
