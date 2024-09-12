using UnityEngine;

namespace Assets.Scripts.Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class MovingRigidbodyController : MonoBehaviour
    {
        #region Fields
        public bool RigidbodyMoving = false;

        [SerializeField] private float _defaultSpeed;
        [SerializeField] private float _runMultiplyer;

        private Rigidbody _rigidbody;
        private float _speed;
        private Vector3 _direction;
        #endregion

        #region Methods
        private void Start()
        {
            this._rigidbody = this.GetComponent<Rigidbody>();
            this._rigidbody.freezeRotation = true;
            this.OnEnable();
            this._speed = this._defaultSpeed;
        }

        private void Update()
        {
            this.MoveByKeys();
        }

        private void MoveByKeys()
        {
            this._speed = this._defaultSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                this._speed *= this._runMultiplyer;
            }

            this._direction.Normalize();
            this._rigidbody.velocity = this.GetDirectionByKeys() * this._speed;
            this._speed = 0;
        }

        private Vector3 GetDirectionByKeys()
        {
            Vector3 direction = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                direction += this.transform.forward;
            }

            if (Input.GetKey(KeyCode.S))
            {
                direction -= this.transform.forward;
            }

            if (Input.GetKey(KeyCode.D))
            {
                direction += this.transform.right;
            }

            if (Input.GetKey(KeyCode.A))
            {
                direction -= this.transform.right;
            }

            return direction;
        }

        private void OnValidate()
        {
            if (this._defaultSpeed < 0)
            {
                this._defaultSpeed = 0;
            }

            if (this._runMultiplyer < 1)
            {
                this._runMultiplyer = 1;
            }
        }

        private void OnEnable()
        {
            Component component;
            if (this.TryGetComponent(typeof(MouseRotationController), out component))
            {
                ((MouseRotationController)component).enabled = !this.enabled;
            }

            if (this.TryGetComponent(typeof(MovingController), out component))
            {
                ((MovingController)component).enabled = !this.enabled;
            }
        }
        #endregion

    }
}