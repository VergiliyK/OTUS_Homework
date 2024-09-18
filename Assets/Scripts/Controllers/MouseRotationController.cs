using UnityEngine;

namespace Assets.Scripts.Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class MouseRotationController : MonoBehaviour
    {

        #region Fields
        [SerializeField] private float _rotationSpeed;
        #endregion

        #region Methods
        private void Start()
        {
            Rigidbody rigidbody = this.GetComponent<Rigidbody>();
            rigidbody.freezeRotation = true;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            this.RotateByMouse();
        }

        private void RotateByMouse()
        {
            this.transform.eulerAngles = new Vector3(
                x: 0,
                y: this.transform.eulerAngles.y + (Input.GetAxis("Mouse X") * this._rotationSpeed),
                z: 0);
        }
        #endregion
    }
}