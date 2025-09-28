using System;
using System.Threading;

namespace VirtualClassroomManager.Services
{
    public static class RetryHandler
    {
        private static readonly Random random = new Random();

        public static T ExecuteWithRetry<T>(Func<T> action, int maxRetries = 3)
        {
            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    if (random.NextDouble() < 0.2)
                        throw new Exception("Simulated transient error");
                    return action();
                }
                catch (Exception) when (attempt < maxRetries)
                {
                    Thread.Sleep(200 * attempt);
                }
            }
            return action();
        }
    }
}
