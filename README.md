# Serilog.Enrichers.Demystify

Unmangle the names of `async` and iterator methods in exception stack traces using @benaadams's Demystifier.

### Getting started

Install from NuGet:

```
Install-Package Serilog.Enrichers.Demystifier
```

Configure log event enrichment:

```csharp
Log.Logger = new LoggerConfiguration()
    .Enrich.WithDemystifiedStackTraces() // <- Add this line
    .WriteTo.Console()
    .CreateLogger();
```

The enricher will replace logged exception stack traces with unmangled ones.

