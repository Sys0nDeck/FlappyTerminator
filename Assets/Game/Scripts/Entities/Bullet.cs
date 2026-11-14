using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    private Faction _faction;
    private Vector3 _startPosition;
    private Vector3 _direction;
    private float _speed;
    private float _flyDistance;
    private Coroutine _shootCoroutine;

    public event Action<Bullet> BulletDestroyed;
    public event Action BulletHitted;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnEnable()
    {
        transform.position = _startPosition;
        transform.right = _direction;
        _shootCoroutine = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        if (_shootCoroutine != null)
        {
            StopCoroutine(_shootCoroutine);
            _shootCoroutine = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Unit unit))
        {
            if (unit.Faction != _faction)
            {
                unit.TakeDamage();
                BulletHitted?.Invoke();
                BulletDestroyed?.Invoke(this);
            }
        }    
    }

    public void Init(Vector3 startPosition, Vector3 direction, float flyDistance, float bulletSpeed, Faction owner)
    {
        _startPosition = startPosition;
        _faction = owner;
        _direction = direction;
        _speed = bulletSpeed;
        _flyDistance = flyDistance;
    }

    private IEnumerator Shoot()
    {
        Vector3 destination = _startPosition + (_direction * _flyDistance);
        float deltaSpeed = 0f;

        while (deltaSpeed < 1f)
        {
            transform.position = Vector3.Lerp(_startPosition, destination, deltaSpeed);
            deltaSpeed += Time.deltaTime * _speed;
            yield return null;
        }

        BulletDestroyed?.Invoke(this);
    }
}
