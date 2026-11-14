using System.Collections;
using UnityEngine;

public class EnemySpawner : EntityPool<Enemy>
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private SpawnField _spawnField;

    private Coroutine _spawnCoroutine;
    private float _spawnDelay = 2f;
    private float _minShootDelay = 1f;
    private float _maxShootDelay = 1.5f;

    private void OnDisable()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
    }

    private void Start()
    {
        _spawnCoroutine = StartCoroutine(Spawn());
    }

    public override void Clear()
    {
        base.Clear();
        _bulletPool.Clear();
    }

    protected override void PoolGet(Enemy entity)
    {
        entity.transform.position = _spawnField.GetRandomPosition();
        entity.transform.right = Vector3.left;
        entity.Init(Random.Range(_minShootDelay, _maxShootDelay), _bulletPool);
        entity.Destroyed += Hide;
        base.PoolGet(entity);
    }

    protected override void PoolRelease(Enemy entity)
    {
        entity.Destroyed -= Hide;
        base.PoolRelease(entity);
    }

    private void Hide(Enemy entity)
    {
        Pool.Release(entity);
    }

    private IEnumerator Spawn()
    {
        var time = new WaitForSeconds(_spawnDelay);
        bool isSpawning = true;

        while (isSpawning)
        {
            yield return time;
            Pool.Get();
        }
    }
}
