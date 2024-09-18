using UnityEngine;

public sealed class HealthComponent : MonoBehaviour
{
    #region Fields
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _health;
    [SerializeField] private float _damageMultiplier;
    #endregion

    public void Awake()
    {
        this._maxHealth = 100;
        this._minHealth = 0;
        this._health = this._maxHealth;
        this._damageMultiplier = 1;
    }

    #region Properties
    public float Health
    {
        get
        {
            return this._health;
        }
        private set
        {
            this._health = Mathf.Clamp(value, this._minHealth, this._maxHealth);
        }
    }

    public float MaxHealth
    {
        get
        {
            return this._maxHealth;
        }
        private set
        {
            if (value <= this._minHealth)
            {
                this._maxHealth = this._minHealth + 1;
            }

            this._maxHealth = value;
        }
    }

    public float MinHealth
    {
        get
        {
            return this._minHealth;
        }
        private set
        {
            this._minHealth = Mathf.Clamp(
                value: value,
                min: 0,
                max: this._maxHealth - 1);
        }
    }

    public bool Alive
    {
        get
        {
            return this.Health > this._minHealth;
        }
    }
    #endregion

    #region Methods
    public float TakeDamage(float baseDamage)
    {
        if (baseDamage < 0 || !this.Alive)
        {
            return 0f;
        }

        float damage = baseDamage * this._damageMultiplier;
        damage = damage <= this.Health ? damage : this.Health;
        this.Health -= damage;
        return damage;
    }
    public void Heal(float healingPoints)
    {
        if (healingPoints < 0 || !this.Alive)
        {
            return;
        }

        this.Health += healingPoints;
    }

    public bool TryHeal(float healingPoints)
    {
        if (healingPoints < 0 || this.CanHeal())
        {
            return false;
        }

        this.Health += healingPoints;
        return true;
    }

    public bool CanHeal()
    {
        return !this.Alive && this.Health != this.MaxHealth;
    }
    #endregion

    public void OnValidate()
    {
        this._health = Mathf.Clamp(this._health, this._minHealth, this._maxHealth);
        this._minHealth = Mathf.Clamp(this._minHealth, 0, this._maxHealth - 1);
        if (this._maxHealth <= this._minHealth)
        {
            this._maxHealth = this._minHealth + 1;
        }
    }
}