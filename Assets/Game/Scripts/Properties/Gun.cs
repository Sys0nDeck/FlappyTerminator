using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _flyDistance = 6f;
    [SerializeField] private float _speed;

    private Faction _owner;
    private BulletPool _bulletPool;

    public void Init(BulletPool pool, Faction owner)
    {
        _bulletPool = pool;
        _owner = owner;
    }

    public void Shoot()
    {
        _bulletPool.Launch(transform.position, transform.right, _flyDistance, _speed, _owner);
    }
}
