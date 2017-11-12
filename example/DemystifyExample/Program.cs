using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Serilog;

namespace DemystifyExample
{
    class Program
    {
        static async Task<int> Main()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithDemystifiedStackTraces()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                return await FailingMethod();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unhandled exception");
                return 1;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        static Task<int> FailingMethod()
        {
            return Task.FromResult(FailingEnumerator().Sum());
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        static IEnumerable<int> FailingEnumerator()
        {
            yield return 1;
            throw new NotImplementedException();
        }
    }
}
