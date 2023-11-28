using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _conteiner;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab, int capacity)
    {
        for (int i = 0; i < capacity; i++)
        {
            GameObject newObject = Instantiate(prefab, _conteiner.transform);
            newObject.SetActive(false);
            _pool.Add(newObject);
        }
    }

    protected bool TryGetObject(out GameObject firstObject)
    {
        do
        {
            firstObject = _pool[Random.Range(0, _pool.Count)];
        }
        while (firstObject.activeSelf == true);

        return firstObject != null;
    }
}
