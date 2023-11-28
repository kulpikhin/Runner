using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _cherriPrefab;
    [SerializeField] private float _spawnTime;
    [SerializeField] private GameObject _pointConteiner;

    private int _enemyCount;
    private int _cherriCount;
    private float _elepsedTime;

    private void Awake()
    {
        _elepsedTime = 0;
        _enemyCount = 20;
        _cherriCount = 5;
        Initialize(_enemyPrefab, _enemyCount);
        Initialize(_cherriPrefab, _cherriCount);
    }

    private void Update()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _spawnTime)
        {
            _elepsedTime = 0;

            if (TryGetObject(out GameObject firstObject))
            {
                firstObject.SetActive(true);
                firstObject.transform.position = GetRandomSpawnPoint();
            }
        }
    }

    private Vector3 GetRandomSpawnPoint()
    {
        int childIndex = Random.Range(0, _pointConteiner.transform.childCount);
        return _pointConteiner.transform.GetChild(childIndex).transform.position;
    }
}
