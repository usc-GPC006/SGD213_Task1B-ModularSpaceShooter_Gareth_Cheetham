using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectMovement : MonoBehaviour
{
    [SerializeField]
     private float acceleration = 50f;
    [SerializeField]
    private float initialVelocity = 2f;
    public bool moveUp = false; // True = up, False = down
    private Vector2 direction; //Calculated from bool
    private Rigidbody2D ourRigidbody;

    public Vector2 Direction {
        get {
            return direction;
        }
        set {
            if (value.magnitude == 1) {
                direction = value;
            } else {
                direction = value.normalized;
            }
        }
    }

    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();
        if (direction == Vector2.zero)  //If the bullet has no transform - This is needed for angled shots from the triple shot
        {
            direction = moveUp ? Vector2.up : Vector2.down;  //Look at moveUp bool, make directions positive or negative accordingly

        }
        ourRigidbody.velocity = Vector2.up * initialVelocity * direction;
    }

    // Update is called once per frame
    void Update()
    {
        ourRigidbody.AddForce(direction*acceleration*Time.deltaTime);
    }
}
