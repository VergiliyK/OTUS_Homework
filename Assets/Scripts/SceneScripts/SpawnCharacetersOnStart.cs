using Assets.Scripts.Components;
using UnityEngine;
using static Assets.Scripts.Components.CharacterCharacteristicComponent;

namespace Assets.Scripts.SceneScripts
{
    public class SpawnCharacetersOnStart : MonoBehaviour
    {
        #region Fields
        [SerializeField] private GameObject _character;
        [SerializeField] private Material _bodyMaterial;
        [SerializeField] private GameObject _spawnPoint;
        [SerializeField] private Vector3 _staicOffset;
        [SerializeField] private Vector3 _dinamicOffset;
        [SerializeField] private int _spawnCount;
        [SerializeField] private CharacterType _characterType;
        #endregion

        #region Methods
        private void Start()
        {
            for (int i = 0; i < this._spawnCount; i++)
            {
                GameObject newCharacter = Instantiate(
                    original: this._character,
                    position: this._spawnPoint.transform.position + this._staicOffset + this._dinamicOffset * i,
                    rotation: Quaternion.Euler(this._spawnPoint.transform.localEulerAngles)
                    );
                newCharacter.GetComponent<CharacterCharacteristicComponent>().Type = this._characterType;
                newCharacter.transform.Find("Body").GetComponent<MeshRenderer>().material = this._bodyMaterial;
                newCharacter.SetActive(true);
            }
        }
        #endregion
    }
}