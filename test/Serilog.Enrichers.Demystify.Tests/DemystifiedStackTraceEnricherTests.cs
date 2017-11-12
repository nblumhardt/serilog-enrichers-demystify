using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Serilog.Events;
using Xunit;

namespace Serilog.Enrichers.Demystify.Tests
{
    public class DemystifiedStackTraceEnricherTests
    {
        [Fact]
        public async Task StackTracesAreDemystified()
        {
            var ex = await ObtainException();
            var enricher = new DemystifiedStackTraceEnricher();
            var le = new LogEvent(DateTimeOffset.UtcNow, LogEventLevel.Error, ex, MessageTemplate.Empty,
                Enumerable.Empty<LogEventProperty>());

            enricher.Enrich(le, null);

            var sts = le.Exception.StackTrace;
            Assert.Contains("async Task<Exception> Serilog.Enrichers.Demystify.Tests.DemystifiedStackTraceEnricherTests.ObtainException()", sts);
        }

        [Fact]
        public async Task ExceptionTypeIsPreserved()
        {
            var ex = await ObtainException();
            var enricher = new DemystifiedStackTraceEnricher();
            var le = new LogEvent(DateTimeOffset.UtcNow, LogEventLevel.Error, ex, MessageTemplate.Empty,
                Enumerable.Empty<LogEventProperty>());

            enricher.Enrich(le, null);

            Assert.IsType<NotImplementedException>(le.Exception);
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        static async Task<Exception> ObtainException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
