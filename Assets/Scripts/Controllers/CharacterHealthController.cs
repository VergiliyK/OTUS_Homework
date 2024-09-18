using UnityEngine;

namespace Assets.Scripts.Controllers
{
    [RequireComponent(typeof(HealthComponent))]
    public sealed class CharacterHealthController : MonoBehaviour
    {
        #region Fields
        private HealthComponent _health;
        #endregion

        #region Methods
        private void Awake()
        {
            this._health = this.GetComponent<HealthComponent>();
        }

        private void Update()
        {
            if (!this._health.Alive)
            {
                this.gameObject.SetActive(false);
                return;
            }

            this.gameObject.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            // Хотелось бы узнать, насколько это хороший способ получать нужные компоненты из other.
            Component item;
            if (other.gameObject.TryGetComponent(typeof(IHealing), out item))
            {
                ((IHealing)item).Heal(this._health);
                return;
            }

            if (other.gameObject.TryGetComponent(typeof(IDamaging), out item))
            {
                ((IDamaging)item).DoDamage(this._health);
                return;
            }
        }
        #endregion

    }
}