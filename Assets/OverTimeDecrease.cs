using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverTimeDecrease : MonoBehaviour
{
    private GameObject _player;

    private Health _health;

    public float decreaseHealth = 3f;

    // Start is called before the first frame update
    void Start()
    {
        _health = _player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        _health.currentHealth -= Time.deltaTime * decreaseHealth;

        if (_health.currentHealth <= 0)
        {
            if (_health.onDie != null)
            {
                _health.m_IsDead = true;
                _health.onDie.Invoke();
            }
        }
    }
}
