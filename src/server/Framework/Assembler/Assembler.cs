using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odysseus.Framework.Assembler
{
    public class Assembler
    {
        public static IEnumerable<TType> CreateImplementationsOf<TType>()
        {
            var assembly = Assembly.GetAssembly(typeof(TType));
            var types = GetAssignableTypesOf<TType>(assembly).Where(type => !type.IsAbstract);

            foreach (var type in types)
                if (Activator.CreateInstance(type) is TType instance)
                    yield return instance;
        }

        private static IEnumerable<Type> GetAssignableTypesOf<TType>(Assembly assembly) =>
            assembly
                .GetTypes()
                .Where(type => typeof(TType).IsAssignableFrom(type));
    }
}