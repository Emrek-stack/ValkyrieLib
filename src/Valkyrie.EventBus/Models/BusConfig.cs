using System;
using System.Collections.Generic;
using Valkyrie.Core.Attributes;

namespace Valkyrie.EventBus.Models
{
    [Configuration("RabbitMq")]
    public class BusConfig
    {
        public BusConfig()
        {
            UseRetry = false;
            UseCluster = false;
            Host = "localhost";
            Username = "guest";
            Password = "guest";
            RetryConfig = new Retry();
            CircuitBreaker =new CircuitBreaker();
            RateLimiter = new RateLimiter();
        }

        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool UseRetry  { get; set; }
        public bool UseCluster { get; set; }
        public bool UseCircuitBreaker { get; set; }
        public bool UseRateLimiter { get; set; }
        public List<string> Nodes { get; set; }
        public Retry RetryConfig { get; set; }
        public CircuitBreaker CircuitBreaker { get; set; }
        public RateLimiter RateLimiter { get; set; }

    }
    public class Retry
    {
        public int RetryCount { get; set; }
        public TimeSpan Interval { get; set; }
    }

    public class CircuitBreaker
    {
        public int? TripThreshold { get; set; }
        public int? ActiveThreshold { get; set; }
        public int? ResetInterval { get; set; }
    }

    public class RateLimiter
    {
        public int? RateLimit { get; set; }
        public int? Interval { get; set; }
    }
}