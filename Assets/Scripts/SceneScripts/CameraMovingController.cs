using UnityEngine;

namespace Assets.Scripts.SceneScripts
{

    public class CameraMovingController : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Transform _characterTransform;
        [SerializeField] private MeshRenderer _characterBodyRender;
        [SerializeField] private int _speed;
        [SerializeField] private float _hightFarOffset;
        [SerializeField] private float _hightCloseOffset;
        [SerializeField] private float _backFarOffset;
        [SerializeField] private float _backCloseOffset;
        [SerializeField] private float _farRotationX;
        [SerializeField] private float _closeRotationX;

        public bool Stop = false;

        private float _rotationX;
        private float _hightOffset;
        private bool _close;
        private float _backOffset;
        #endregion

        #region Methods
        private void Start()
        {
            this.transform.position = this.GetNewPosition();
            this._close = true;
            this._backOffset = this._backCloseOffset;
            this.SetDistanceSettings();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                this.ChangeDistance();
            }

            this.MoveAndRotate();
        }

        private void ChangeDistance()
        {
            this._close = !this._close;
            this.SetDistanceSettings();
        }

        private void MoveAndRotate()
        {
            this.transform.SetPositionAndRotation(
            position: Vector3.Lerp(
                a: this.transform.position,
                b: this.GetNewPosition(),
                t: Time.deltaTime * this._speed),
            rotation: Quaternion.Euler(
                x: this._rotationX,
                y: this._characterTransform.eulerAngles.y,
                z: this._characterTransform.eulerAngles.z));
        }

        private void SetDistanceSettings()
        {
            this._backOffset = this._close ? this._backCloseOffset : this._backFarOffset;
            this._hightOffset = this._close ? this._hightCloseOffset : this._hightFarOffset;
            this._rotationX = this._close ? this._closeRotationX : this._farRotationX;
            this._characterBodyRender.enabled = !this._close;
        }

        private Vector3 GetNewPosition()
        {
            return new Vector3(
                x: this._characterTransform.position.x - (this._characterTransform.forward.x * this._backOffset),
                y: this._characterTransform.position.y + this._hightOffset,
                z: this._characterTransform.position.z - (this._characterTransform.forward.z * this._backOffset));
        }
        #endregion
    }
}