using UnityEngine;

namespace Assets.Scripts.Components
{
    public sealed class CharacterCharacteristicComponent : MonoBehaviour
    {
        public enum CharacterType
        {
            Neutral = 0,
            Ally = 1,
            Enemy = 2,
            EnemyToAll = 3
        }

        public CharacterType Type;

    }
}