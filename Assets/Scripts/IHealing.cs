using UnityEngine;

namespace Assets.Scripts
{
    internal interface IHealing
    {
        public float HealingPoints
        {
            get;
        }

        public void Heal(HealthComponent health);
        public bool TryHeal(GameObject gameObject);

    }
}
