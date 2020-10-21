using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUpgradePickup : MonoBehaviour
{
    private Pickup m_Pickup;
    // Start is called before the first frame update
    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, JetpackPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    // Update is called once per frame
    void OnPicked(PlayerCharacterController byPlayer)
    {
        byPlayer.jumpForce = 9;
        Destroy(gameObject);
    }
}
