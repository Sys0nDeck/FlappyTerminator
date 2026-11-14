using System;
using UnityEngine;

public class Terminator : Unit
{
    [SerializeField] private Mover _mover;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Gun _gun;
    [SerializeField] private BulletPool _bulletPool;

    public event Action Damaged;

    private void Start()
    {
        _gun.Init(_bulletPool, Faction);
    }

    public override void TakeDamage()
    {
        Damaged?.Invoke();
    }

    public void Reset()
    {
        _mover.Reset();
        _scoreCounter.Reset();
    }
}
