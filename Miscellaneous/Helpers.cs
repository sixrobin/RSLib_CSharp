namespace RSLib.CSharp;

public class Helpers {
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
}