using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTripleShot : WeaponBase {

    /// <summary>
    /// Shoot will spawn a three bullets, provided enough time has passed compared to our fireDelay.
    /// </summary>
    public override void Shoot() {
        // get the current time
        float currentTime = Time.time;
        // if enough time has passed since our last shot compared to our fireDelay, spawn our bullet
        if (currentTime - lastFiredTime > fireDelay) {
            float x = -0.5f;
            // create 3 bullets
            for (int i = 0; i < 3; i++) {
                // create our bullet
                GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
                // Check bullet orientation (Enemy or Player's bullet up or down)
                GenericObjectMovement bulletMovement = newBullet.GetComponent<GenericObjectMovement>();
                float y = bulletMovement.moveUp ? 0.5f : -0.5f;
                //Set the movement
                bulletMovement.Direction = new Vector2(x + 0.5f * i, y);
            }

            // update our shooting state
            lastFiredTime = currentTime;
        }
    }
}
