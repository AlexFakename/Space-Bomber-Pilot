using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Field")]
    [SerializeField] Transform minXPoint, maxXPoint, minYPoint, maxYPoint;
    [Header("Enemys")]
    [SerializeField] GameObject enemy1Prefab, enemy2Prefab;
    [Header("SpawnTimers")]
    [SerializeField] float enemy1SpawnTime = 5f, enemy2SpawnTime = 15f;
    //float timeSinceStart;
    float timerEnemy1;
    float timerEnemy2;
    //bool spawnCheckpoint1 = false;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy1();
    }

    // Update is called once per frame
    void Update()
    {
        //timeSinceStart += Time.deltaTime;
        timerEnemy1 += Time.deltaTime;
        if (timerEnemy1 >= enemy1SpawnTime) { SpawnEnemy1(); timerEnemy1 -= enemy1SpawnTime; }
        timerEnemy2 += Time.deltaTime;
        if (timerEnemy2 >= enemy2SpawnTime) { SpawnEnemy2(); timerEnemy2 -= enemy2SpawnTime; }
    }

    private void SpawnEnemy1()
    {
        GameObject enemy1 = Instantiate(enemy1Prefab, RandomSpawnPosition(), Quaternion.identity);
    }

    private void SpawnEnemy2() { Instantiate(enemy2Prefab, RandomSpawnPosition(), Quaternion.identity); }

    public float GetMinX() { return minXPoint.position.x; }
    public float GetMaxX() { return maxXPoint.position.x; }
    public float GetMinY() { return minYPoint.position.y; }
    public float GetMaxY() { return maxYPoint.position.y; }

    private Vector3 RandomSpawnPosition()
    {
        Vector3 myVector3 = new Vector3(Random.Range(minXPoint.position.x, maxXPoint.position.x), Random.Range(minYPoint.position.y, maxYPoint.position.y), 0);
        return myVector3;
    }

}