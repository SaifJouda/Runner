using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damageAmount = 1; // Amount of damage to deal

    void Start()
    {
        Destroy(gameObject, 1f);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "Enemy" tag or specific script/component
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            other.gameObject.GetComponent<EnemyAI>().Damage(damageAmount);
            // Destroy the projectile on collision with the enemy
            Destroy(gameObject);
        }
    }
}