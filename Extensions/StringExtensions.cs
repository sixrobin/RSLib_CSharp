namespace RSLib.CSharp.Extensions
{
    using System.Text;

    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string to its upper case version.
        /// For instance, AttackSpeedMultiplier would become ATTACK_SPEED_MULTIPLIER.
        /// Does not take acronyms into account.
        /// </summary>
        /// <param name="s">String to convert.</param>
        /// <returns>Converted string.</returns>
        public static string ToUpperCase(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return "";
        
            StringBuilder newText = new(s.Length * 2);
            newText.Append(s[0]);
        
            for (int i = 1; i < s.Length; i++)
            {
                if (char.IsUpper(s[i]))
                    newText.Append('_');
            
                newText.Append(s[i]);
            }
        
            return newText.ToString().ToUpper();
        }
        
        /// <summary>
        /// Converts a string to its snake case version.
        /// For instance, AttackSpeedMultiplier would become attack_speed_multiplier.
        /// Does not take acronyms into account.
        /// </summary>
        /// <param name="s">String to convert.</param>
        /// <returns>Converted string.</returns>
        public static string ToSnakeCase(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return "";
        
            StringBuilder newText = new(s.Length * 2);
            newText.Append(s[0]);
        
            for (int i = 1; i < s.Length; i++)
            {
                if (char.IsUpper(s[i]))
                    newText.Append('_');
            
                newText.Append(s[i]);
            }
        
            return newText.ToString().ToLower();
        }
    }
}