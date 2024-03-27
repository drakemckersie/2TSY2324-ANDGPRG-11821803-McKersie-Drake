using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hitPoints = 2f;
    [SerializeField] private int currencyWorth = 50;

    private bool isDestroyed = false;
    public LayerMask towerLayer;

  public void TakeDamage(float dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDestroyed)
        {
            float range = 15f;

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, towerLayer);

            foreach (var hitCollider in hitColliders)
            {
                TowerAttack tower = hitCollider.GetComponent<TowerAttack>();
                if (tower != null)
                {
                    tower.EnemyDestroyed(gameObject);
                }
            }

            SpawnerController.onEnemyDestroy.Invoke();
            GameManager.Instance.IncreaseCurrency(currencyWorth);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }


  
}
