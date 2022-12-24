using Unity.Mathematics;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class Plant_SunBloom : MonoBehaviour
{
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private GameObject sunPrefab;
    [SerializeField] private float firstSpawnTime, spawnRepeatRate,spawnDuration;
    [SerializeField] private Ease sunEase;


    void Start()
    {
        InvokeRepeating(nameof(CreateSun),firstSpawnTime,UnityEngine.Random.Range(spawnRepeatRate,spawnRepeatRate+1.5f));
       
    }

    private void CreateSun()
    {
        var spawnedSun = Instantiate(sunPrefab, spawnTransform.position, quaternion.identity);
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnedSun.transform.position.x - .5f, spawnedSun.transform.position.x + .5f),
            Random.Range(spawnedSun.transform.position.y + .6f, spawnedSun.transform.position.y + .9f),
            Random.Range(spawnedSun.transform.position.z - .5f, spawnedSun.transform.position.z + .5f));

        spawnedSun.transform.DOMove(randomPosition, spawnDuration).SetEase(sunEase);
    }
}
