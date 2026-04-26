using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : DetectCollisionBase
{
    [SerializeField]
    private int damageToDeal;
    //Whenever there is a collision
    protected override void ProcessCollision(GameObject other)
    {
        base.ProcessCollision(other);
        //Check to see if the other object has health, if it does, deal damage to it and destroy this object
        if (other.GetComponent<IHealth>() != null) 
        {
            other.GetComponent<IHealth>().TakeDamage(damageToDeal);
            Destroy(gameObject);
        } 
        //Otherwise, print the object name that doesn't have health
        else 
        {
            Debug.Log(other.name + " does not have an IHealth component");
        }
    }
}
