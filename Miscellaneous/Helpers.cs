namespace RSLib.CSharp
{
    public class Helpers
    {
        /// <summary>
        /// Custom modulo operating method to handle negative values.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="n">Second operand.</param>
        /// <returns>Modulo result.</returns>
        public static int Mod(int a, int n)
        {
            return (a % n + n) % n;
        }

        /// <summary>
        /// Merges multipliers (with a base value of 1.0 for 100%) into one multiplier.
        /// For instance, 1.1 and 1.2 would result in a multiplier of 1.3.
        /// </summary>
        /// <param name="multipliers">Multipliers to merge.</param>
        /// <returns>Merged multiplier.</returns>
        public static float MergeMultipliers(params float[] multipliers)
        {
            float result = 1f;

            foreach (float multiplier in multipliers)
                result += multiplier - 1f;

            return result;
        }
    }
}