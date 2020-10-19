using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decrease_MovementSpeedOverTime : MonoBehaviour
{
    // public variable for decreasing speed 
    public float decreaseSpeed = 0.3f;
    public float decreaseHealth = 3f;
    public float decreaseBob = 0.15f;

    public PlayerCharacterController MyCharacter;
    public Health MyCharacterHealth;
    public PlayerWeaponsManager CharacterBob;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Decreases the movement speed over time
        MyCharacter.maxSpeedInAir -= Time.deltaTime * decreaseSpeed;

        MyCharacter.maxSpeedOnGround -= Time.deltaTime * decreaseSpeed;

        // Decrease weapon bob over time
        CharacterBob.bobFrequency -= Time.deltaTime * decreaseBob;

        // Decreases the health over time and when it reaches 0 the player dies
        MyCharacterHealth.currentHealth -= Time.deltaTime * decreaseHealth;

        if (MyCharacterHealth.currentHealth <= 0)
        {
            if (MyCharacterHealth.onDie != null)
            {
                MyCharacterHealth.m_IsDead = true;
                MyCharacterHealth.onDie.Invoke();
            }
        }
    }
}
