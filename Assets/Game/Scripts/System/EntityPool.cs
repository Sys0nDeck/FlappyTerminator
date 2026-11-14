using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class EntityPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapacity = 10;
    [SerializeField] private int _poolMaxSize = 30;

    private ObjectPool<T> _pool;
    private HashSet<T> _activeEntities;

    protected ObjectPool<T> Pool => _pool;


    private void Awake()
    {
        _activeEntities = new HashSet<T>();

        _pool = new ObjectPool<T>(
            createFunc: () => PoolCreate(),
            actionOnGet: (obj) => PoolGet(obj),
            actionOnRelease: (obj) => PoolRelease(obj),
            actionOnDestroy: (obj) => PoolDestroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public virtual void Clear()
    {
       foreach (var entity in _activeEntities.ToArray<T>())
            _pool.Release(entity);

        _activeEntities.Clear();
    }

    protected virtual T PoolCreate()
    {
        var obj = Instantiate(_prefab);
        obj.gameObject.SetActive(false);
        return obj;
    }

    protected virtual void PoolDestroy(T entity)
    {
        Destroy(entity);
    }

    protected virtual void PoolGet(T entity)
    {
        _activeEntities.Add(entity);
        entity.gameObject.SetActive(true);
    }

    protected virtual void PoolRelease(T entity)
    {
        _activeEntities.Remove(entity);
        entity.gameObject.SetActive(false);
    }
}
