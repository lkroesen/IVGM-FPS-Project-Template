using UnityEngine;

public class GravityPickup : MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("Newgravity after picking up")]
    public float NewGravity;
    public float jumppower;

    Pickup m_Pickup;

    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, GravityPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player)
    {
        PlayerCharacterController playerPlayerCharacterController = player.GetComponent<PlayerCharacterController>();

	playerPlayerCharacterController.SetGravity(NewGravity, jumppower);

        m_Pickup.PlayPickupFeedback();

        Destroy(gameObject);
    }
}
