using System;
using System.Collections.Generic;
using System.Linq;

namespace Vculp.Api.Common.Common
{
    public abstract class Mapper<T>
    {
        private static Dictionary<Type, Func<T, object>> _toDestinationMappings;
        private static Dictionary<Type, Func<object, T>> _fromSourceMappings;

        static Mapper()
        {
            _toDestinationMappings = new Dictionary<Type, Func<T, object>>();
            _fromSourceMappings = new Dictionary<Type, Func<object, T>>();
        }

        protected static void CreateMapTo<TDestination>(Func<T, object> mappingFunc)
        {
            _toDestinationMappings[typeof(TDestination)] = mappingFunc;
        }

        protected static void CreateMapFrom<TSource>(Func<object, T> mappingFunc)
        {
            _fromSourceMappings[typeof(TSource)] = mappingFunc;
        }

        public static TDestination MapTo<TDestination>(T source)
        {
            if (source == null)
            {
                return default(TDestination);
            }

            var destinationType = typeof(TDestination);

            if (!_toDestinationMappings.ContainsKey(destinationType))
            {
                throw new InvalidOperationException($"No mapping exists to type {destinationType}. A mapping must be created for mapping to be performed.");
            }

            return (TDestination)_toDestinationMappings[destinationType](source);
        }

        public static T MapFrom<TSource>(TSource source)
        {
            if (source == null)
            {
                return default(T);
            }

            var sourceType = typeof(TSource);

            if (!_fromSourceMappings.ContainsKey(sourceType))
            {
                throw new InvalidOperationException($"No mapping exists from type {sourceType}. A mapping must be created for mapping to be performed.");
            }

            return _fromSourceMappings[sourceType](source);
        }

        public static IEnumerable<T> MapFrom<TSource>(IEnumerable<TSource> collection)
        {
            if (collection == null)
            {
                return null;
            }

            if (!collection.Any())
            {
                Enumerable.Empty<T>();
            }

            var sourceType = typeof(TSource);
            if (!_fromSourceMappings.ContainsKey(sourceType))
            {
                throw new InvalidOperationException($"No mapping exists from type {sourceType}. A mapping must be created for mapping to be performed.");
            }

            return collection.Select(x => MapFrom(x));
        }
    }
}
