using System;

public class BulletPoolWithScoreEvent : BulletPool
{
    public event Action ScoreIncreasing;

    protected override void PoolGet(Bullet entity)
    {
        entity.BulletHitted += OnBulletHit;
        base.PoolGet(entity);
    }

    protected override void PoolRelease(Bullet entity)
    {
        entity.BulletHitted -= OnBulletHit;
        base.PoolRelease(entity);
    }

    private void OnBulletHit()
    {
        ScoreIncreasing?.Invoke();
    }
}
