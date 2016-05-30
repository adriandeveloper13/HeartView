using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;

namespace DataLayer
{

    public class TransientFaultHelper
    {
        private const string RETRY_COUNT_KEY = "RetryPolicyRetryCount";
        private const string RETRY_INTERVAL_KEY = "RetryPolicyRetryInterval";

        public static RetryPolicy<CustomTransientErrorDetectionStrategy> GetRetryPolicy()
        {
            int retryCount, retryInterval = 0;
            if (int.TryParse(ConfigurationManager.AppSettings[RETRY_COUNT_KEY], out retryCount) &&
                int.TryParse(ConfigurationManager.AppSettings[RETRY_INTERVAL_KEY], out retryInterval))
            {
                if (retryCount <= 0 || retryCount > 6)
                {
                    retryCount = 3;
                }

                if (retryInterval <= 0 || retryInterval > 6)
                {
                    retryInterval = 1;
                }
            }
            else
            {
                retryCount = 1;
                retryInterval = 1;
            }

            var retryStrategy = new FixedInterval(retryCount, TimeSpan.FromSeconds(retryInterval));

            return new RetryPolicy<CustomTransientErrorDetectionStrategy>(retryStrategy);
        }
    }

    // this might need some changes in the future, but for now it's ok, since there is no SqlDatabaseTransientErrorDetectionStrategy implementation
    // or I am too stupid to find it ...
    public class CustomTransientErrorDetectionStrategy : ITransientErrorDetectionStrategy
    {
        public bool IsTransient(Exception ex)
        {
            return true;
        }
    }
}