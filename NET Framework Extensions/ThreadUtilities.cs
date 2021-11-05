namespace System.Threading
{
    public static class ThreadUtilities
    {
        public static Thread CreateBackgroundThread(ThreadStart start)
        {
            return new Thread(start)
            {
                IsBackground = true,
                Priority = ThreadPriority.BelowNormal
            };
        }
    }
}
