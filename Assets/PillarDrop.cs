using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarDrop : MonoBehaviour
{
    [SerializeField] private GameObject[] _pillars;
    [SerializeField] private GameObject _replacement;

    private GameObject[] _newPillars;
    // Start is called before the first frame update
    void Start()
    {
        _newPillars = new GameObject[_pillars.Length];
        
        for (int i = 0; i < _pillars.Length; i++)
        {
            _newPillars[i] = Instantiate(_replacement, _pillars[i].transform.position, _pillars[i].transform.rotation);
            Destroy(_pillars[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
