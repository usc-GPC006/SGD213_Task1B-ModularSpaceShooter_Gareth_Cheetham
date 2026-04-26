using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pickup is an object aimed at passing weapon functionality to player objects. Depending on
/// the specified weaponType, the Pickup will tell the player object what object it should now
/// use as it's weapon.
/// </summary>
public class Pickup : MonoBehaviour
{
    [SerializeField]
    public PickupType pickupType;
    [SerializeField]
    private int healingAmount = 10;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject player = col.gameObject;
            HandlePlayerPickup(player);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject player = col.gameObject;
            HandlePlayerPickup(player);
        }
    }

    /// <summary>
    /// HandlePlayerPickup handles all of the actions after a player has been collided with.
    /// It grabs the IWeapon component from the player, transfers all information to a
    /// new IWeapon (based on the provided weaponType).
    /// </summary>
    /// <param name="player"></param>
    private void HandlePlayerPickup(GameObject player)
    {
        // get the playerInput from the player
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        // handle a case where the player doesnt have a PlayerInput
        if (playerInput == null) {
            Debug.LogError("Player doesn't have a PlayerInput component.");
            return;
        } else if (pickupType == PickupType.healthPack)
        {
            IHealth health = player.GetComponent<IHealth>();
            if (health != null)
            {
                health.Heal(healingAmount);
            }
        }
        // tell the playerInput to SwapWeapon based on our weaponType
        else
        {
            playerInput.SwapWeapon(pickupType);
            Destroy(gameObject);
        }
    }
}

public enum PickupType {machineGun, tripleShot, healthPack}
