using System;
using UnityEngine;

public class L2HomeworkExperienceComponent : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private float _nextLevelLimitMultipier = 1.3f;
    [SerializeField]
    private int _levelExperienceLimit = 100;
    [SerializeField]
    private int _experience = 0;
    [SerializeField]
    private int _level = 0;
    [SerializeField]
    private int _levelUpsNumber = 0;
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
                Debug.LogWarning("Experience must not be a negative number.");
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
            Debug.LogWarning("Experience points' number must not be negative.");
            return;
        }
        Experience += experiencePoints;
        Debug.Log($"I've gained {experiencePoints} experience points. EXP = {Experience}");
        while (Experience >= _levelExperienceLimit)
        {
            LevelUpsNumber += 1;
            _levelExperienceLimit = Convert.ToInt32(_nextLevelLimitMultipier * _levelExperienceLimit);
        }
        IsLevelUpAvailable();
    }

    private bool IsLevelUpAvailable()
    {
        if (LevelUpsNumber > 0)
        {
            Debug.Log(LevelUpsNumber == 1 ?
                "Level up is available." :
                $"{LevelUpsNumber} level ups are available.");
            return true;
        }
        Debug.Log("No level up is available.");
        return false;
    }

    public void LevelUp()
    {
        if (IsLevelUpAvailable())
        {
            Level++;
            LevelUpsNumber--;
            Debug.Log($"Level up! Current level is {Level}");
        }
    }
    #endregion
}
