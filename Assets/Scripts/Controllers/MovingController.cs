using UnityEngine;

namespace Assets.Scripts.Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MouseRotationController))]
    public sealed class MovingController : MonoBehaviour
    {
        #region Fields
        public bool RigidbodyMoving = false;

        [SerializeField] private float _defaultSpeed;
        [SerializeField] private float _runMultiplyer;

        private float _speed;
        private Vector3 _direction;
        #endregion

        #region Methods
        private void Start()
        {
            Rigidbody rigidbody = this.GetComponent<Rigidbody>();
            rigidbody.freezeRotation = true;
            this.OnEnable();
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
            this.transform.Translate(this._speed * Time.deltaTime * this.GetDirectionByKeys());
            this._speed = 0;
        }
        private Vector3 GetDirectionByKeys()
        {
            Vector3 direction = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                direction += Vector3.forward;
            }

            if (Input.GetKey(KeyCode.S))
            {
                direction -= Vector3.forward;
            }

            if (Input.GetKey(KeyCode.D))
            {
                direction += Vector3.right;
            }

            if (Input.GetKey(KeyCode.A))
            {
                direction -= Vector3.right;
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
                ((MouseRotationController)component).enabled = this.enabled;
            }

            if (this.TryGetComponent(typeof(MovingRigidbodyController), out component))
            {
                ((MovingRigidbodyController)component).enabled = this.enabled;
            }
        }
        #endregion
    }
}