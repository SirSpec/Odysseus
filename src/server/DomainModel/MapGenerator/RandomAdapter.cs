﻿using System;

namespace Odysseus.DomainModel.MapGenerator
{
    public class RandomAdapter : IRandomNumberEngine
    {
        private readonly Random random;

        public RandomAdapter() => random = new Random();

        public RandomAdapter(int seed) => random = new Random(seed);

        public int RandomInteger(ConstraintRange<int> constraint) =>
            random.Next(constraint.Min, constraint.Max);

        public double RandomDouble(ConstraintRange<double> constraint) =>
            (random.NextDouble() * (constraint.Max - constraint.Min)) + constraint.Min;
    }
}
