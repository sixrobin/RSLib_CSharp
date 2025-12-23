namespace RSLib.CSharp.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class DictionaryExtensions
    {
        #region GENERAL

        /// <summary>
        /// Loops through all KeyValuePairs in the dictionary and executes an action.
        /// </summary>
        /// <param name="dict">Dictionary to loop through.</param>
        /// <param name="action">Action to execute.</param>
        public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue> dict, System.Action<TKey, TValue> action)
        {
            foreach (KeyValuePair<TKey, TValue> kvp in dict)
                action(kvp.Key, kvp.Value);
        }

        /// <summary>
        /// Checks the value for key TKey and returns it, or returns the default value for TValue if key was not found.
        /// </summary>
        /// <param name="dict">Dictionary to get the value in, if contained.</param>
        /// <param name="key">Key to look for.</param>
        /// <param name="customDefault">Custom default value to use in case key is not found.</param>
        /// <returns>Found existing value, or default TValue value.</returns>
        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue customDefault = default)
        {
            return dict.TryGetValue(key, out TValue value) ? value : customDefault;
        }

        /// <summary>
        /// Checks the value for key TKey and returns it, or returns the default value for TValue and triggers a callback if key was not found.
        /// </summary>
        /// <param name="dict">Dictionary to get the value in, if contained.</param>
        /// <param name="key">Key to look for.</param>
        /// <param name="defaultUsedCallback">Callback triggered if key is not found.</param>
        /// <param name="customDefault">Custom default value to use in case key is not found.</param>
        /// <returns>Found existing value, or default TValue value.</returns>
        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, System.Action defaultUsedCallback, TValue customDefault = default)
        {
            if (dict.TryGetValue(key, out TValue value))
                return value;

            defaultUsedCallback?.Invoke();
            return customDefault;
        }

        /// <summary>
        /// Checks the value for key TKey and returns it, or creates a new pair if key was not found.
        /// </summary>
        /// <param name="dict">Dictionary get the value in if contained or insert new instance.</param>
        /// <param name="key">Key to look for.</param>
        /// <returns>Found existing value, or created one.</returns>
        public static TValue GetOrInsertNew<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key) where TValue : new()
        {
            if (dict.TryGetValue(key, out TValue value))
                return value;

            TValue newObj = new TValue();
            dict[key] = newObj;
            return newObj;
        }

        /// <summary>
        /// Checks the value for key TKey and returns it, or creates a new pair and triggers a callback if key was not found.
        /// </summary>
        /// <param name="dict">Dictionary to get the value in if contained or insert new instance.</param>
        /// <param name="key">Key to look for.</param>
        /// <param name="insertNewCallback">Callback triggered if key is not found.</param>
        /// <returns>Found existing value, or created one.</returns>
        public static TValue GetOrInsertNew<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, System.Action insertNewCallback) where TValue : new()
        {
            if (dict.TryGetValue(key, out TValue value))
                return value;

            TValue newObj = new TValue();
            dict[key] = newObj;

            insertNewCallback?.Invoke();

            return newObj;
        }

        #endregion // GENERAL
        
        #region RANDOM
        
        /// <summary>
        /// Gets a random key using values as weights.
        /// </summary>
        /// <param name="dict">Dictionary to get a random key from.</param>
        /// <returns>Randomly selected key.</returns>
        public static TKey GetRandomKey<TKey>(this Dictionary<TKey, int> dict)
        {
            int totalWeight = dict.Sum(kvp => kvp.Value);
            double randomWeight = new System.Random().NextDouble() * totalWeight;
            double currentWeight = 0;

            foreach (KeyValuePair<TKey, int> kvp in dict)
            {
                currentWeight += kvp.Value;
                if (currentWeight >= randomWeight)
                    return kvp.Key;
            }

            return dict.Keys.Last();
        }
        
        /// <summary>
        /// Gets a random key using values as weights.
        /// </summary>
        /// <param name="dict">Dictionary to get a random key from.</param>
        /// <returns>Randomly selected key.</returns>
        public static TKey GetRandomKey<TKey>(this Dictionary<TKey, float> dict)
        {
            float totalWeight = dict.Sum(kvp => kvp.Value);
            double randomWeight = new System.Random().NextDouble() * totalWeight;
            double currentWeight = 0;

            foreach (KeyValuePair<TKey, float> kvp in dict)
            {
                currentWeight += kvp.Value;
                if (currentWeight >= randomWeight)
                    return kvp.Key;
            }

            return dict.Keys.Last();
        }
        
        /// <summary>
        /// Gets a random key using values as weights.
        /// </summary>
        /// <param name="dict">Dictionary to get a random key from.</param>
        /// <returns>Randomly selected key.</returns>
        public static TKey GetRandomKey<TKey>(this Dictionary<TKey, double> dict)
        {
            double totalWeight = dict.Sum(kvp => kvp.Value);
            double randomWeight = new System.Random().NextDouble() * totalWeight;
            double currentWeight = 0;

            foreach (KeyValuePair<TKey, double> kvp in dict)
            {
                currentWeight += kvp.Value;
                if (currentWeight >= randomWeight)
                    return kvp.Key;
            }

            return dict.Keys.Last();
        }
        
        #endregion // RANDOM
    }
}