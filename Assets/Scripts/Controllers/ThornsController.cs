using UnityEngine;

namespace Assets.Scripts.Controllers
{
    internal class ThornsController : MonoBehaviour, IDamaging
    {
        #region Fields
        [SerializeField] private float _baseDamage;
        #endregion

        #region Properties
        public float BaseDamage
        {
            get
            {
                return this._baseDamage;
            }
            private set
            {
                if (value < 0)
                {
                    this._baseDamage = 0;
                }

                this._baseDamage = value;
            }
        }
        #endregion

        #region Methods
        public void DoDamage(HealthComponent health)
        {
            health.TakeDamage(this.BaseDamage);
        }

        public bool TryDoDamage(GameObject gameObject)
        {
            Component component;
            if (!gameObject.TryGetComponent(typeof(HealthComponent), out component))
            {
                return false;
            }
            this.DoDamage((HealthComponent)component);
            return true;
        }
        #endregion
    }
}
