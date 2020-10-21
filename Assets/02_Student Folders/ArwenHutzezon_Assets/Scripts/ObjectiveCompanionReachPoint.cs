using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Objective), typeof(Collider))]
public class ObjectiveCompanionReachPoint : MonoBehaviour
{
    [Tooltip("Visible transform that will be destroyed once the objective is completed")]
    public Transform destroyRoot;

    [SerializeField] private int _index;

    Objective m_Objective;
    private bool _objectiveCompleted = false;

    void Awake()
    {
        m_Objective = GetComponent<Objective>();
        DebugUtility.HandleErrorIfNullGetComponent<Objective, ObjectiveCompanionReachPoint>(m_Objective, this, gameObject);

        if (destroyRoot == null)
            destroyRoot = transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if (m_Objective.isCompleted)
            return;

        CompanionBehaviour companion = other.GetComponent<CompanionBehaviour>();
        Debug.Log(companion);
        // test if the other collider contains a PlayerCharacterController, then complete
        if (companion != null && companion.GetPackLeader().CompareTag("Player"))
        {
            m_Objective.CompleteObjective(string.Empty, string.Empty, "Objective complete : " + m_Objective.title);

            companion.Follow();

            if (GetComponentInParent<ObjectiveUnlocker>())
            {
                GetComponentInParent<ObjectiveUnlocker>().ObjectiveCompleted(_index);
            }

            // destroy the transform, will remove the compass marker if it has one
            Destroy(destroyRoot.gameObject);
        }
    }

    public int GetIndex()
    {
        return _index;
    }
}
