using UnityEngine;

namespace Assets.Scripts
{
    public interface ISpawning
    {
        public GameObject ToSpawn
        {
            get;
        }
        public void Spawn(Transform parent);
    }
}