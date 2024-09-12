using UnityEngine;

namespace Assets.Scripts.Controllers
{
    internal sealed class SpawnPointController : MonoBehaviour, ISpawning
    {
        #region Fields
        [SerializeField] private GameObject _toSpawn;
        #endregion

        #region Methods
        public GameObject ToSpawn
        {
            get
            {
                return this._toSpawn;
            }
            private set
            {
                this._toSpawn = value;
            }
        }

        public void Spawn(Transform parent)
        {
            Instantiate(
                original: this._toSpawn,
                position: this.transform.position,
                rotation: Quaternion.identity,
                parent: parent);
        }

        #endregion
    }
}
