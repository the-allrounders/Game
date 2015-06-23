using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    public static class HelperFunctions
    {
        /// <summary>
        /// A random. Yaj!
        /// </summary>
        public static Random Rnd = new Random();
        
        /// <summary>
        /// Randomizes a IEnumerable.
        /// Usage: ienumerable.Randomize()
        /// </summary>
        /// <returns>The shuffled ienumerable</returns>
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            return source.OrderBy<T, int>((item) => Rnd.Next());
        }

        /// <summary>
        /// Randomizes a List.
        /// Usage: list.Randomize()
        /// </summary>
        /// <returns>The shuffled list</returns>
        public static List<T> Randomize<T>(this List<T> source)
        {
            return source.OrderBy<T, int>((item) => Rnd.Next()).ToList();
        }
    }
}
