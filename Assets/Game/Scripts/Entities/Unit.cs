using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private Faction _faction;

    public Faction Faction => _faction;

    public abstract void TakeDamage();
}
