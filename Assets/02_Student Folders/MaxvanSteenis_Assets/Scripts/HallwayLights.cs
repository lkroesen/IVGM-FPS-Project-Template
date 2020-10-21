using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayLights : MonoBehaviour
{
    [SerializeField] private GameObject[] _crystalsToReplace;
    [SerializeField] private GameObject _replacement;

    private GameObject[] _newCrystals;
    private CrystalLight[] _crystalLight;
    // Start is called before the first frame update
    void Start()
    {
        _newCrystals = new GameObject[_crystalsToReplace.Length];
        _crystalLight = new CrystalLight[_crystalsToReplace.Length];
        for (int i = 0; i < _crystalsToReplace.Length; i++)
        {
            _newCrystals[i] = Instantiate(_replacement, _crystalsToReplace[i].transform.position,
                _crystalsToReplace[i].transform.rotation) as GameObject;
            Destroy(_crystalsToReplace[i]);
            _crystalLight[i] = _newCrystals[i].GetComponent<CrystalLight>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < _newCrystals.Length; i++)
            {
                _crystalLight[i].LightOn();
            }
        }
    }
}
