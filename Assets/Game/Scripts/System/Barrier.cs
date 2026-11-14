using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Barrier : MonoBehaviour
{
    private Collider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void Start()
    {
        _collider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Unit unit))
            unit.TakeDamage();
    }
}
