using _Scripts;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    public GameObject prefab;
    public float spawnRate = 1;
    public float minHeight = -1;
    public float maxHeight = 1;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    public void Spawn()
    {
        GameObject pipe = objectPool.GetPoolObject();
        pipe.SetActive(true);
        pipe.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}