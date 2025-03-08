namespace RSLib.CSharp.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class HashSetExtensions
    {
        private static System.Random s_rnd = new System.Random();

        /// <summary>
        /// Returns any randomly picked element.
        /// </summary>
        /// <param name="hashSet">HashSet to get any element from.</param>
        /// <returns>Any element.</returns>
        public static T RandomElement<T>(this HashSet<T> hashSet)
        {
            return hashSet.ElementAt(s_rnd.Next(hashSet.Count));
        }
    }
}