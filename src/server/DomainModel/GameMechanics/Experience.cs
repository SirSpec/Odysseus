using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Experience
    {
        public event EventHandler<int>? LeveledUp;

        public int Level { get; private set; }
        public int Points { get; private set; }

        public Experience(int points)
        {
            if (points < 0)
                throw new ArgumentException($"{nameof(points)}:{points} cannot be less than 0.");

            (Points, Level) = (points, CalculateLevel(points));
        }

        public void Gain(int experience)
        {
            if (experience > 0)
            {
                Points += experience;

                var level = CalculateLevel(Points);
                if (level > Level) LeveledUp?.Invoke(this, level);

                Level = level;
            }
            else throw new ArgumentException($"{nameof(experience)}:{experience} cannot be less than 0.");
        }

        private int CalculateLevel(int experience)
        {
            return 1;
        }
    }
}
