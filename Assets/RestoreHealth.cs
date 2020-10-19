using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHealth : MonoBehaviour
{
    public PlayerCharacterController MyCharacter;
    public Health MyCharacterHealth;
    public PlayerWeaponsManager CharacterBob;

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

    void OnTriggerEnter (Collider other)
    {
        MyCharacter.maxSpeedInAir = 10f;

        MyCharacter.maxSpeedOnGround = 13f;

        CharacterBob.bobFrequency = 10f;

        MyCharacterHealth.currentHealth = 100f;

        Destroy(gameObject);
    }
}
