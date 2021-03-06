using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;

    private GameObject _spawned;
    public event UnityAction RestartButtonClicked;

    private void Start()
    {
        gameObject.SetActive(true);
        RestartButtonClicked?.Invoke();
        StartCoroutine(SpawnEnemy());
    }

    private void CleanSpawner()
    {
        StopCoroutine(SpawnEnemy());

        foreach (var item in _prefabs)
            Destroy(item);
    }

    private IEnumerator SpawnEnemy()
    {
        int spawnPoint = -5;
        float minSpawnPointLevel = -1.2f;
        float maxSpawnPointLevel = 1.2f;

        yield return new WaitForSeconds(2f);

        gameObject.SetActive(true);
        _spawned = Instantiate(_prefabs[Random.Range(0, 3)], new Vector2(spawnPoint, Random.Range(minSpawnPointLevel, maxSpawnPointLevel)), Quaternion.identity);
        Start();
    }
}
