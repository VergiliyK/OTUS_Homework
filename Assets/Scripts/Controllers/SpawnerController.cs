using UnityEngine;

namespace Assets.Scripts.Controllers
{
    internal sealed class SpawnerController : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Transform _parentObject;
        #endregion

        #region Methods
        private void Start()
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                Component spawner;
                if (this.transform.GetChild(i).TryGetComponent(typeof(ISpawning), out spawner))
                {
                    ((ISpawning)spawner).Spawn(this._parentObject);
                }
            }
        } 
        #endregion
    }
}
