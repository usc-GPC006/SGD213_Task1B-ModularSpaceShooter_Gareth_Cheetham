using UnityEngine;

[RequireComponent(typeof (PlayerMovementScript), typeof (ShootingScript))]

public class PlayerInput : MonoBehaviour
{
    private PlayerMovementScript playerMovementScript;
    private ShootingScript shootingScript;
    // Start is called before the first frame update


    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovementScript>();
        
        shootingScript = GetComponent<ShootingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementInput = Input.GetAxis("Horizontal");

        if (Input.GetButton("Fire1")) 
        {
            shootingScript.Shoot();
        }

        if (movementInput != 0.0f)
        {
            playerMovementScript.MovePlayer(movementInput);
        }
    }
}
