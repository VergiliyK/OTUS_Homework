using UnityEngine;

namespace Assets.Scripts.SceneScripts
{

    public class CameraMovingController : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Transform _characterTransform;
        [SerializeField] private int _speed;
        [SerializeField] private float _hightOffset;
        [SerializeField] private float _backOffset;
        [SerializeField] private float _rotationX;

        public bool Stop = false;
        #endregion

        #region Methods
        private void Start()
        {
            this.transform.position = this.GetNewPosition();
        }

        private void Update()
        {
            this.MoveAndRotate();
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