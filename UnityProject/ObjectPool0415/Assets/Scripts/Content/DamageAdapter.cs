using UnityEngine;
using UnityEngine.Events;

public class DamageAdapter : MonoBehaviour, IDamagable
{
    public UnityEvent<GameObject, int> OnDamaged;

    public void TakeDamage(GameObject attacker, int damage)
    {
        OnDamaged?.Invoke(attacker, damage);
    }
}
