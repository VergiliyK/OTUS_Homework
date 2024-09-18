using System;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public sealed class ExperienceComponent : MonoBehaviour
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
                return this._experience;
            }
            private set
            {
                if (value < 0)
                {
                    this._experience = 0;
                    return;
                }

                this._experience = value;
            }
        }
        public int Level
        {
            get
            {
                return this._level;
            }
            private set
            {
                if (value < 0)
                {
                    this._level = 0;
                    return;
                }

                this._level = value;
            }
        }

        public int LevelUpsNumber
        {
            get
            {
                return this._levelUpsNumber;
            }
            private set
            {
                if (value < 0)
                {
                    this._levelUpsNumber = 0;
                    return;
                }

                this._levelUpsNumber = value;
            }
        }
        #endregion

        #region Methods
        public void GainExperience(int experiencePoints)
        {
            if (this._levelExperienceLimit < 0)
            {
                return;
            }

            this.Experience += experiencePoints;
            while (this.Experience >= this._levelExperienceLimit)
            {
                this.LevelUpsNumber += 1;
                this._levelExperienceLimit = Convert.ToInt32(this._nextLevelLimitMultipier * this._levelExperienceLimit);
            }

            this.IsLevelUpAvailable();
        }

        private bool IsLevelUpAvailable()
        {
            if (this.LevelUpsNumber > 0)
            {
                return true;
            }

            return false;
        }

        public void LevelUp()
        {
            if (this.IsLevelUpAvailable())
            {
                this.Level++;
                this.LevelUpsNumber--;
            }
        }
        #endregion
    }
}