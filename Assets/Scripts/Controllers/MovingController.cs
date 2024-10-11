using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public sealed class MovingController : MonoBehaviour, IMoving
    {
        #region Fields
        [SerializeField] private float _defaultSpeed;
        [SerializeField] private float _runMultiplyer;

        private float _speed;
        private Vector3 _direction;
        #endregion

        #region Properties
        public bool Moving
        {
            get
            {
                return this._direction != Vector3.zero;
            }
        }
        #endregion

        #region Methods
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

            this.SetDirectionByKeys();
            this.transform.Translate(this._speed * Time.deltaTime * this._direction);
        }
        private void SetDirectionByKeys()
        {
            if (Input.GetKey(KeyCode.W))
            {
                this._direction += Vector3.forward;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this._direction -= Vector3.forward;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this._direction += Vector3.right;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                this._direction -= Vector3.right;
            }
            else
            {
                this._direction = Vector3.zero;
                return;
            }

            this._direction.Normalize();
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

        #endregion
    }
}