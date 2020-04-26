using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odysseus.Framework.Assembler
{
    public class Assembler
    {
        public static IEnumerable<TType> CreateImplementationOf<TType>()
        {
            var assembly = Assembly.GetAssembly(typeof(TType));
            var types = GetTypes<TType>(assembly).Where(type => !type.IsAbstract);

            foreach (var type in types)
                if (Activator.CreateInstance(type) is TType instance)
                    yield return instance;
        }

        public static IEnumerable<Type> GetTypes<TType>(Assembly assembly) =>
            assembly
                .GetTypes()
                .Where(type => DoesImplement<TType>(type));

        public static bool DoesImplement<TType>(Type type) =>
            type.IsSubclassOf(typeof(TType)) || type.GetInterfaces().Contains(typeof(TType));
    }
}