using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    #region Fields
    [SerializeField] private float _health = 100;
    [SerializeField] private float _damageMultiplier = 1;
    #endregion

    #region Properties
    public float Health
    {
        get
        {
            return _health;
        }
        private set
        {
            if (value < 0)
            {
                _health = 0;
                return;
            }
            _health = value;
        }
    }

    public bool Alive
    {
        get
        {
            return Health > 0;
        }
    }
    #endregion

    #region Methods
    public void TakeDamage(float baseDamage)
    {
        if (baseDamage < 0)
        {
            return;
        }
        if (!Alive)
        {
            return;
        }
        float damage = baseDamage * _damageMultiplier;
        damage = damage <= Health ? damage : Health;
        Health -= damage;
    }
    #endregion
}