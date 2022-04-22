using Polly;
using Polly.Retry;

namespace RequestService.Policies
{

    public class ClientPolicy
    {
        public AsyncRetryPolicy<HttpResponseMessage> ImmediateHttpretry { get; }
        public AsyncRetryPolicy<HttpResponseMessage> linearHttpretry { get; }
        public AsyncRetryPolicy<HttpResponseMessage> ExponentialHttpretry { get; }



        public ClientPolicy()
        {
            ImmediateHttpretry = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode
            ).RetryAsync(5);

            linearHttpretry = Policy.HandleResult<HttpResponseMessage>(
            res => !res.IsSuccessStatusCode
        ).WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(3));
            ExponentialHttpretry = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode
            ).WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

    }

}