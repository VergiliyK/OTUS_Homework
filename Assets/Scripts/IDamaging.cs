using UnityEngine;

namespace Assets.Scripts
{
    internal interface IDamaging
    {
        public float BaseDamage
        {
            get;
        }

        public void DoDamage(HealthComponent health);
        public bool TryDoDamage(GameObject gameObject);
    }
}
