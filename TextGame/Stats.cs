using System;

namespace TextGame
{
    /// <summary>
    /// A player's stats.
    /// </summary>
    class Stats
    {
        /// <summary>
        /// The possible stat types.
        /// </summary>
        public enum StatType
        {
            Strength,
            Intelligence,
            Charisma,
        }

        private uint strength;
        private uint intelligence;
        private uint charisma;

        public Stats()
            : this(10, 10, 10) { }

        public Stats(uint strength, uint intelligence, uint charisma)
        {
            this.strength = strength;
            this.intelligence = intelligence;
            this.charisma = charisma;
        }

        /// <summary>
        /// Get a stat.
        /// </summary>
        /// <param name="statType">The stat type</param>
        /// <returns>The stat value</returns>
        public uint GetStat(StatType statType)
        {
            switch (statType) {
                case StatType.Strength:
                    return strength;
                case StatType.Intelligence:
                    return intelligence;
                case StatType.Charisma:
                    return charisma;
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Set a stat.
        /// </summary>
        /// <param name="statType">The stat type</param>
        /// <param name="value">The new stat value</param>
        public void SetStat(StatType statType, uint value)
        {
            switch (statType)
            {
                case StatType.Strength:
                    strength = value;
                    break;
                case StatType.Intelligence:
                    intelligence = value;
                    break;
                case StatType.Charisma:
                    charisma = value;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Adds a value to a stat.
        /// </summary>
        /// <param name="statType">The stat type</param>
        /// <param name="value">The value</param>
        public void AddToStat(StatType statType, uint value)
        {
            switch (statType)
            {
                case StatType.Strength:
                    strength += value;
                    break;
                case StatType.Intelligence:
                    intelligence += value;
                    break;
                case StatType.Charisma:
                    charisma += value;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Subtracts a value from a stat.
        /// </summary>
        /// <param name="statType">The stat type</param>
        /// <param name="value">The value to subtract</param>
        public void SubtractFromStat(StatType statType, uint value)
        {
            switch (statType)
            {
                case StatType.Strength:
                    strength -= value;
                    break;
                case StatType.Intelligence:
                    intelligence -= value;
                    break;
                case StatType.Charisma:
                    charisma -= value;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
