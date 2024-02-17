using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] float sizeX = 5f;
    [SerializeField] float sizeY = 5f;
    [SerializeField] float spawnCooldown = 10f;

    private float spawnTime;

    void Start()
    {
        spawnTime = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime > 0) spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            Spawn();
            spawnTime = spawnCooldown;
        }
    }

    void Spawn()
    {
        float xPos = (Random.value - 0.5f) * 2 * sizeX + gameObject.transform.position.x;
        float yPos = (Random.value - 0.5f) * 2 * sizeY + gameObject.transform.position.y;

        var spawn = Instantiate(EnemyPrefab);

        spawn.transform.position = new Vector3(xPos, yPos, 0);


    }
}


