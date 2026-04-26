using System;
using UnityEngine;

/// <summary>
/// PlayerInput handles all of the player specific input behaviour, and passes the input information
/// to the appropriate scripts.
/// </summary>
public class PlayerInput : MonoBehaviour
{
    // local references
    private EngineBase playerMovement;
    private WeaponBase weapon;
    public WeaponBase Weapon
    {
        get
        {
            return weapon;
        }

        set
        {
            weapon = value;
        }
    }

    void Start()
    {
        playerMovement = GetComponent<EngineBase>();
        weapon = GetComponent<WeaponBase>();
    }

    void Update()
    {
        // Read our horizontal input axis
        float horizontalInput = Input.GetAxis("Horizontal");
        // If movement input is not zero
        if (horizontalInput != 0.0f)
        {
            // Ensure our playerMovementScript is populated to avoid errors
            if (playerMovement != null)
            {
                // Pass our movement input to our playerMovementScript
                playerMovement.Accelerate(horizontalInput * Vector2.right);
            }
        }

        // If we press the Fire1 button
        if (Input.GetButton("Fire1"))
        {
            // If our WeaponBase is populated
            if (weapon != null)
            {
                // Tell WeaponBase to shoot
                weapon.Shoot();
            }
        }
    }

    /// <summary>
    /// SwapWeapon handles creating a new WeaponBase component based on the given weaponType. This
    /// will popluate the newWeapon's controls and remove the existing weapon ready for usage.
    /// </summary>
    /// <param name="weaponType">The given weaponType to swap our current weapon to, this is an enum in WeaponBase.cs</param>
    public void SwapWeapon(PickupType weaponType)
    {
        // make a new weapon dependent on the weaponType
        WeaponBase newWeapon = null;
        switch (weaponType)
        {
            case PickupType.machineGun:
                newWeapon = gameObject.AddComponent<WeaponMachineGun>();
                break;
            case PickupType.tripleShot:
                newWeapon = gameObject.AddComponent<WeaponTripleShot>();
                break;
        }

        // update the data of our newWeapon with that of our current weapon
        newWeapon.UpdateWeaponControls(weapon);
        // remove the old weapon
        Destroy(weapon);
        // set our current weapon to be the newWeapon
        weapon = newWeapon;
    }
}
