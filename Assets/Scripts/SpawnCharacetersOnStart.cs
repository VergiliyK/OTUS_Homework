using System.Threading;
using UnityEngine;

public class SpawnCharacetersOnStart : MonoBehaviour
{
    #region Fields
    public enum CharacterType
    {
        Neutral = 0,
        Ally = 1,
        Enemy = 2,
        EnemyToAll = 3
    }

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
        for (int i = 0; i < _spawnCount; i++)
        {
            GameObject newCharacter = Instantiate(_character, _spawnPoint.transform.position + _staicOffset + (_dinamicOffset * i), Quaternion.Euler(_spawnPoint.transform.localEulerAngles));
            CharacterCharacteristicComponent characteristicComponent = newCharacter.GetComponent<CharacterCharacteristicComponent>();
            switch (_characterType)
            {
                case CharacterType.Ally:
                    characteristicComponent.Ally = true;
                    break;
                case CharacterType.Enemy:
                    characteristicComponent.Enemy = true;
                    break;
                case CharacterType.EnemyToAll:
                    characteristicComponent.EnemyToAll = true;
                    break;
                default:
                    characteristicComponent.Neutral = true;
                    break;
            }
            newCharacter.transform.Find("Body").GetComponent<MeshRenderer>().material = _bodyMaterial;
            newCharacter.SetActive(true);
        }
    }
    #endregion
}
