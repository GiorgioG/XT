using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XT.FP
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<U> Map<T, U>(this T? value, Func<T, U> transform)
        {
            if (value == null) return new List<U>();
            return new List<U> {transform(value)}.Where(v => v != null);
        }

        public static IEnumerable<U> Map<T, U>(this IEnumerable<T>? value, Func<T, U> transform)
        {
            if (value == null) return new List<U>();
            return value.Select(transform).Where(v => v != null);
        }

        public static async Task<IEnumerable<U>> MapAsync<T, U>(this T? value, Func<T, Task<U>> transform)
        {
            if (value == null) return new List<U>();
            return new List<U> {await transform(value)}.Where(v => v != null);
        }

        public static async Task<IEnumerable<U>> MapAsync<T, U>(this IEnumerable<T>? value, Func<T, Task<U>> transform)
        {
            if (value == null ) return new List<U>();
            return (await Task.WhenAll(value.Select(async v => await transform(v)))).Where(v => v != null);
        }

        public static IEnumerable<U> FlatMap<T, U>(this T? value, Func<T, IEnumerable<U>> transform)
        {
            if (value == null) return new List<U>();
            return new List<T> {value}.SelectMany(transform).Where(v => v != null);
        }

        public static IEnumerable<U> FlatMap<T, U>(this IEnumerable<T>? value, Func<T, IEnumerable<U>> transform)
        {
            if (value == null) return new List<U>();
            return value.SelectMany(transform).Where(v => v != null);
        }

        public static IEnumerable<U> FlatMap<T, U>(this IEnumerable<IEnumerable<T>>? value,
            Func<IEnumerable<T>, IEnumerable<U>> transform)
        {
            if (value == null) return new List<U>();
            return value.SelectMany(transform).Where(v => v != null);
        }

    }
}