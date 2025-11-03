using UnityEngine;

public interface IDamageable
{
    void Damage(float damageAmmount);

    void Die();

    float MaxHealth { get; set; }
    float CurrentHeatlh { get; set; }
}
