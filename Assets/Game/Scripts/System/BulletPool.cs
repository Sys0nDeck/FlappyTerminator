using UnityEngine;

public class BulletPool : EntityPool<Bullet>
{
    public void Launch(Vector3 startPosition, Vector3 direction, float flyDistance, float speed, Faction ownerFaction)
    {
        var bullet = Pool.Get();
        bullet.Init(startPosition, direction, flyDistance, speed, ownerFaction);
        bullet.gameObject.SetActive(true);
    }

    protected override void PoolGet(Bullet entity)
    {
        entity.BulletDestroyed += ReleaseBullet;
        base.PoolGet(entity);
        entity.gameObject.SetActive(false);
    }

    protected override void PoolRelease(Bullet entity)
    {
        entity.BulletDestroyed -= ReleaseBullet;
        base.PoolRelease(entity);
    }

    private void ReleaseBullet(Bullet bullet)
    {
        Pool.Release(bullet);
    }  
}
