using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAmbush : MonoBehaviour
{
    [SerializeField] private GameObject[] _rocks;
    [SerializeField] private GameObject[] _enemies;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject rock in _rocks)
        {
            rock.SetActive(false);
        }

        foreach (GameObject enemy in _enemies)
        {
            enemy.SetActive(false);
            enemy.GetComponent<CompassElement>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject rock in _rocks)
            {
                rock.SetActive(true);
            }

            foreach (GameObject enemy in _enemies)
            {
                enemy.SetActive(true);
                enemy.GetComponent<CompassElement>().enabled = true;
            }
        }

        GetComponent<BoxCollider>().enabled = false;
    }
}
