using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractProjectile : MonoBehaviour
{
    protected int damage;

    public void SetDamage (int damage)
    {
        this.damage = damage;
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            EnemyHealth enemy = other.gameObject.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);

            if (!other.gameObject.CompareTag("turret"))
            {
                Destroy(gameObject);
            }

        }
    }

}
