namespace System.Collections.Generic
{
    public static class ListExtension
    {
        private static readonly string _listEmptyErrorMessage = "Error: List is empty!";

        public static bool IsEmpty<T>(this List<T> list)
        {
            return list == null || list.Count == 0;
        }

        public static bool IsNotEmpty<T>(this List<T> list)
        {
            return list.IsEmpty() == false;
        }

        public static T FirstIndexOf<T>(this List<T> list)
        {
            if (list.IsNotEmpty())
            {
                return list[0];
            }
            else
            {
                throw new NullReferenceException(ListExtension._listEmptyErrorMessage);
            }
        }

        public static T LastIndexOf<T>(this List<T> list)
        {
            if (list.IsNotEmpty())
            {
                return list[list.Count - 1];
            }
            else
            {
                throw new NullReferenceException(ListExtension._listEmptyErrorMessage);
            }
        }

        public static T RandomIndexOf<T>(this List<T> list)
        {
            if (list.IsNotEmpty())
            {
                return list[UnityEngine.Random.Range(0, list.Count)];
            }
            else
            {
                throw new NullReferenceException(ListExtension._listEmptyErrorMessage);
            }
        }
    }
}
