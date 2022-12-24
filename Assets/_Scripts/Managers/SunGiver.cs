using Unity.Mathematics;
using UnityEngine;


public class SunGiver : MonoBehaviour
{

    [SerializeField] private GameObject sunPrefab;
    [SerializeField] private float firstSpawnTime, spawnRepeatRate;

    private void Start()
    {
        InvokeRepeating(nameof(CreateSun),firstSpawnTime,UnityEngine.Random.Range(spawnRepeatRate,spawnRepeatRate+5));
    }

    private void CreateSun()
    {
        Vector3 sunCreatePos = new Vector3(UnityEngine.Random.Range(4, 10), transform.position.y, UnityEngine.Random.Range(1, 5));
        Instantiate(sunPrefab, sunCreatePos, quaternion.identity);
    }
}
