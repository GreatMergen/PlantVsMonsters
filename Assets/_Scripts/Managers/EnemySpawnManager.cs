using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager instance;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private float spawnTimeBetweenEnemies;
    [Tooltip("Düşman kalitesini belirler 60 altı kesin easyEnemy,80 altı orta basit karışık,100 ve altı en zoru")]
    [SerializeField] private int spawnQuality;
    [SerializeField] private int enemyNumber;
    [SerializeField] private GameObject easyEnemyPrefab,midEnemyPrefab,hardEnemyPrefab;
    private int _spawnPosNumber, _spawnedEnemyCount;
    public bool enemySpawnDone;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    void Start()
    {
        _spawnedEnemyCount = enemyNumber;
        StartCoroutine(SpawnEnemyLoop(spawnQuality));
    }

    private IEnumerator SpawnEnemyLoop(int enemyQuality)
    {
        for (int i = 0; i < enemyNumber; i++)
        {
            
                _spawnPosNumber = Random.Range(0, spawnPositions.Length);
                Instantiate(EnemyQualitySelect(enemyQuality), spawnPositions[_spawnPosNumber].position, Quaternion.Euler(0,-90,0));
                _spawnedEnemyCount--;
                if (_spawnedEnemyCount > 0)
                {
                    yield return new WaitForSeconds(spawnTimeBetweenEnemies);
                }
                else
                {
                    print("Enemy bitti");
                    enemySpawnDone = true;
                    yield break;
                }
        }
        
    }
    
    private GameObject EnemyQualitySelect(int enemyQualitySelect)
    {
        var  enemyQuality = Random.Range(0, enemyQualitySelect);
        if (enemyQuality < 60)
        {
            return easyEnemyPrefab;
        }
        else if (enemyQuality < 80)
        {
            return midEnemyPrefab;
        }
        else if (enemyQuality < 100)
        {
            return hardEnemyPrefab;
        }

        return null;
    }
}
