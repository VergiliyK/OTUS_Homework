using UnityEngine;

public class CharacterCharacteristicComponent : MonoBehaviour
{
    [SerializeField] private bool _isAlly = false;
    [SerializeField] private bool _isEnemy = false;
    [SerializeField] private bool _isEnemyToAll = false;

    public bool Ally
    {
        get
        {
            return _isAlly;
        }
        set
        {
            if (value == true)
            {
                _isEnemy = false;
                _isEnemyToAll = false;
            }
            _isAlly = value;
        }
    }
    public bool Enemy
    {
        get
        {
            return _isEnemy;
        }
        set
        {
            if (value == true)
            {
                _isAlly = false;
                _isEnemyToAll = false;
            }
            _isEnemy = value;
        }
    }
    public bool EnemyToAll
    {
        get
        {
            return _isEnemyToAll;
        }
        set
        {
            if (value == true)
            {
                _isAlly = false;
                _isEnemy = false;
            }
            _isEnemyToAll = value;
        }
    }
    public bool Neutral
    {
        get
        {
            return !_isAlly && !_isEnemy && !_isEnemyToAll;
        }
        set
        {
            if (value == true)
            {
                _isAlly = false;
                _isEnemy = false;
                _isEnemyToAll = false;
            }
        }
    }
}