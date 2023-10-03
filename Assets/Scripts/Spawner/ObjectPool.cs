using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] protected Bird Bird;

    private List<GameObject> _pool = new List<GameObject>();   

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {            
            GameObject enemy = Instantiate(prefab, _container.transform);
            enemy.GetComponent<Enemy>().Init(Bird);
            enemy.SetActive(false);
            _pool.Add(enemy);
        }
    }

    protected void ResetPool()
    {
        foreach (var enemy in _pool)
        {
            enemy.SetActive(false);
            enemy.GetComponent<EnemyShooter>().ResetPool();
        }
    }

    protected bool TryGetEnemy(out GameObject enemy)
    {
        enemy = _pool.FirstOrDefault(enemy => enemy.activeSelf == false);

        return enemy != null;
    }
}
