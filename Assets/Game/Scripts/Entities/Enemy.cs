using System;
using System.Collections;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private Gun _gun;

    private Coroutine _shootCoroutine;
    private float _shootDelay;

    public event Action<Enemy> Destroyed;

    private void OnEnable()
    {
        _shootCoroutine = StartCoroutine(StartShooting(_shootDelay));
    }

    private void OnDisable()
    {
        if (_shootCoroutine != null)
        {
            StopCoroutine(_shootCoroutine);
            _shootCoroutine = null;
        }
    }

    public void Init(float shootDelay, BulletPool bulletPool)
    {
        _shootDelay = shootDelay;
        _gun.Init(bulletPool, Faction);
    }

    public override void TakeDamage()
    {
        Destroyed?.Invoke(this);
    }
    
    private IEnumerator StartShooting(float time)
    {
        var delay = new WaitForSeconds(time);
        bool isShooting = true;

        while (isShooting)
        {
            yield return delay;
            _gun.Shoot();     
        }
    }
}
