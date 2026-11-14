using UnityEngine;

public class DamagedZone : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private Collider2D _collider2D;

    private void Start()
    {
        _collider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Unit unit))
            if (unit.Faction != _unit.Faction)
                unit.TakeDamage();
    }
}
