using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveUnlocker : MonoBehaviour
{
    [Header("Objectives")] 
    [SerializeField] private GameObject[] _objectives;
    [SerializeField] private GameObject _objectiveToUnlock;

    private bool[] _objectivesCompleted;
    // Start is called before the first frame update
    void Start()
    {
        _objectivesCompleted = new bool[_objectives.Length];
        foreach (GameObject objective in _objectives)
        {
            objective.SetActive(true);
        }
        StartCoroutine(SetEndObjective());
    }

    // Update is called once per frame
    void Update()
    {
        AllObjectivesCompleted();
    }

    public void ObjectiveCompleted(int index)
    {
        _objectivesCompleted[index] = true;
    }

    void AllObjectivesCompleted()
    {
        foreach (bool objective in _objectivesCompleted)
        {
            if (!objective)
            {
                return;
            }
        }
        
        _objectiveToUnlock.SetActive(true);
    }

    IEnumerator SetEndObjective()
    {
        yield return new WaitForSeconds(1);
        _objectiveToUnlock.SetActive(false);
    }

    public bool CheckObjective(int index)
    {
        return _objectivesCompleted[index];
    }
}
