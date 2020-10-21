using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPassage : MonoBehaviour
{
    [SerializeField] private GameObject _objectiveManager;
    [SerializeField] private GameObject _prerequisite;

    private ObjectiveUnlocker _objectiveUnlocker;
    private int _objectiveIndex;
    // Start is called before the first frame update
    void Start()
    {
        ObjectiveCompanionReachPoint objective = _prerequisite.GetComponent<ObjectiveCompanionReachPoint>();
        if (objective)
        {
            _objectiveIndex = objective.GetIndex();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ObjectiveUnlocker _objectiveUnlocker = _objectiveManager.GetComponent<ObjectiveUnlocker>();
        if (_objectiveUnlocker.CheckObjective(_objectiveIndex))
        {
            Destroy(gameObject);
        }
    }
}
