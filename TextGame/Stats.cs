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
            Thirst,
        }

        private uint strength;
        private uint intelligence;
        private uint charisma;
        private uint thirst;

        public Stats()
            : this(10, 10, 10, 0) { }

        public Stats(uint strength, uint intelligence, uint charisma, uint thirst)
        {
            this.strength = strength;
            this.intelligence = intelligence;
            this.charisma = charisma;
            this.thirst = thirst;
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
                case StatType.Thirst:
                    return thirst;
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
                case StatType.Thirst:
                    thirst = value;
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
                case StatType.Thirst:
                    thirst += value;
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
                    strength -= Math.Min(value, strength);
                    break;
                case StatType.Intelligence:
                    intelligence -= Math.Min(value, intelligence);
                    break;
                case StatType.Charisma:
                    charisma -= Math.Min(value, charisma);
                    break;
                case StatType.Thirst:
                    thirst -= Math.Min(value, thirst);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        public void ViewStats()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Your stats are as follows:");
            foreach (StatType statType in Enum.GetValues(typeof(StatType)))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"\t{statType}: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(GetStat(statType));
            }
        }
    }
}
