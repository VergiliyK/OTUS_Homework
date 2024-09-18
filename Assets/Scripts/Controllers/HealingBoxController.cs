using UnityEngine;

namespace Assets.Scripts.Controllers
{
    internal sealed class HealingBoxController : MonoBehaviour, IHealing
    {
        #region Fields
        [SerializeField] private float _healingPoints;
        #endregion

        #region Properties
        public float HealingPoints
        {
            get
            {
                return this._healingPoints;
            }
            private set
            {
                if (value < 0)
                {
                    this._healingPoints = 0;
                }

                this._healingPoints = value;
            }
        }
        #endregion

        #region Methods
        public void Heal(HealthComponent healthComponent)
        {
            if (healthComponent.Health == healthComponent.MaxHealth)
            {
                return;
            }

            healthComponent.Heal(this.HealingPoints);
            this.gameObject.SetActive(false);
        }

        public bool TryHeal(GameObject gameObject)
        {
            Component component;
            if (!gameObject.TryGetComponent(typeof(HealthComponent), out component))
            {
                return false;
            }

            this.Heal((HealthComponent)component);
            return true;
        }
    }
    #endregion
}
