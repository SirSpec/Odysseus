using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Experience
    {
        private const int Minimum = 0;

        public event EventHandler<Level>? LeveledUp;

        public Level Level { get; private set; }
        public int Points { get; private set; }

        public Experience(int points)
        {
            if (points < Minimum)
                throw new ArgumentException($"{nameof(points)}:{points} cannot be less than {Minimum}.");

            (Points, Level) = (points, CalculateLevel(points));
        }

        public void Gain(int experience)
        {
            if (experience > Minimum)
            {
                Points += experience;

                var level = CalculateLevel(Points);
                if (level.Value > Level.Value) LeveledUp?.Invoke(this, level);

                Level = level;
            }
            else throw new ArgumentException($"{nameof(experience)}:{experience} cannot be less than {Minimum}.");
        }

        private Level CalculateLevel(int experience) =>
            new Level((int)Math.Floor((25 + Math.Sqrt(625 + 100 * experience)) / 50));
    }
}