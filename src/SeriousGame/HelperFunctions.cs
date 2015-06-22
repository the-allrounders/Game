using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    public static class HelperFunctions
    {
        /// <summary>
        /// Randomizes a IEnumerable.
        /// Usage: ienumerable.Randomize()
        /// </summary>
        /// <returns>The shuffled ienumerable</returns>
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            Random rnd = new Random();
            return source.OrderBy<T, int>((item) => rnd.Next());
        }

        /// <summary>
        /// Randomizes a List.
        /// Usage: list.Randomize()
        /// </summary>
        /// <returns>The shuffled list</returns>
        public static List<T> Randomize<T>(this List<T> source)
        {
            Random rnd = new Random();
            return source.OrderBy<T, int>((item) => rnd.Next()).ToList();
        }
    }
}
