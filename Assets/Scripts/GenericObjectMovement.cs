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
    private float direction; //Calculated from bool
    private Rigidbody2D ourRigidbody;

    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();
        direction = moveUp ? 1f : -1f;  //Look at moveUp bool, make directions positive or negative accordingly
        ourRigidbody.velocity = Vector2.up * initialVelocity * direction;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 forceToAdd = Vector2.up * acceleration * Time.deltaTime * direction;
        ourRigidbody.AddForce(forceToAdd);
    }
}
