using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MonsterType
{
    Ground,
    Flying,
    Boss,
}
public class Enemy : MonoBehaviour
{
   
    [SerializeField] NavMeshAgent agent;
    [SerializeField] MonsterType monsterType;
    public CrystalHealth health;

    // Start is called before the first frame update
    void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
        //agent.SetDestination(target.position);
    }

    // Update is called once per frame
   public void SetTarget(Transform target)
    {
        agent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Crystal"))
        {
            SpawnerController.Instance.RemoveEnemy(this);
            SpawnerController.onEnemyDestroy.Invoke();
            Destroy(this.gameObject);

        
          GameManager.Instance.TakeDamage(5f);
        }
    }
}
