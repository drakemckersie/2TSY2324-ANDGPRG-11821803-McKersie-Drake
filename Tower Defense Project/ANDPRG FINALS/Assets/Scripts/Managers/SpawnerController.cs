using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerController : MonoBehaviour
{
    public static SpawnerController Instance;

    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform spawnPoint;
    [SerializeField] List<Enemy> enemyList = new List<Enemy>();

    //

    public static UnityEvent onEnemyDestroy = new UnityEvent();

    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 3f;
    [SerializeField] private float difficultyScaling = 0.75f;
    [SerializeField] private float enemiesPerSecondCap = 5f;

    public int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private float eps;
    private bool isSpawning = false;


    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(StartWave());
        
    }

    private void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / eps) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }

    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
        eps = EnemiesPerSecond();
    }

   private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScaling));
    }

    private float EnemiesPerSecond()
    {
        return Mathf.Clamp(enemiesPerSecond * Mathf.Pow(currentWave, difficultyScaling), 0f, enemiesPerSecondCap);
    }

    private void SpawnEnemy()
    {
        int idx = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyObj = (GameObject)Instantiate(enemyPrefabs[idx], spawnPoint.position,Quaternion.identity);
        enemyObj.GetComponent<Enemy>().SetTarget(GameManager.Instance.CrystalCore.transform);
        enemyList.Add(enemyObj.GetComponent<Enemy>());
    }
    
    public void RemoveEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);
    }


}
