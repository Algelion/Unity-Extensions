namespace System.Collections.Generic
{
    public static class DictionaryExtension
    {
        public static bool IsEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return dictionary == null || dictionary.Count == 0;
        }

        public static bool IsNotEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return dictionary.IsEmpty() == false;
        }
    }
}
