using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ReplaceCrystals : MonoBehaviour
{
    [SerializeField] private GameObject _crystalPrefab;

    [SerializeField] private GameObject[] _crystalsToReplace;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _crystalsToReplace.Length; i++)
        {
            Instantiate(_crystalPrefab, _crystalsToReplace[i].transform.position,
                _crystalsToReplace[i].transform.rotation);
            Destroy(_crystalsToReplace[i]);
        }
    }
}
