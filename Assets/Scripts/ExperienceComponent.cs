using System;
using UnityEngine;

public class ExperienceComponent : MonoBehaviour
{
    #region Fields
    [SerializeField] private float _nextLevelLimitMultipier = 1.3f;
    [SerializeField] private int _levelExperienceLimit = 100;
    [SerializeField] private int _experience = 0;
    [SerializeField] private int _level = 0;
    [SerializeField] private int _levelUpsNumber = 0;
    #endregion

    #region Properties
    public int Experience
    {
        get
        {
            return _experience;
        }
        private set
        {
            if (value < 0)
            {
                _experience = 0;
                return;
            }
            _experience = value;
        }
    }
    public int Level
    {
        get
        {
            return _level;
        }
        private set
        {
            if (value < 0)
            {
                Debug.LogWarning("Level must not be a negative number.");
                _level = 0;
                return;
            }
            _level = value;
        }
    }

    public int LevelUpsNumber
    {
        get
        {
            return _levelUpsNumber;
        }
        private set
        {
            if (value < 0)
            {
                Debug.LogWarning("Level ups number must not be negative.");
                _levelUpsNumber = 0;
                return;
            }
            _levelUpsNumber = value;
        }
    }
    #endregion

    #region Methods
    public void GainExperience(int experiencePoints)
    {
        if (_levelExperienceLimit < 0)
        {
            return;
        }
        Experience += experiencePoints;
        while (Experience >= _levelExperienceLimit)
        {
            LevelUpsNumber += 1;
            _levelExperienceLimit = Convert.ToInt32(_nextLevelLimitMultipier * _levelExperienceLimit);
        }
    }

    private bool IsLevelUpAvailable()
    {
        if (LevelUpsNumber > 0)
        {
            return true;
        }
        return false;
    }

    public void LevelUp()
    {
        if (IsLevelUpAvailable())
        {
            Level++;
            LevelUpsNumber--;
        }
    }
    #endregion
}
