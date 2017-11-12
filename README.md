# Serilog.Enrichers.Demystify [![NuGet Pre Release](https://img.shields.io/nuget/vpre/serilog.enrichers.demystify.svg)](https://www.nuget.org/packages/serilog.enrichers.demystify) [![Build status](https://ci.appveyor.com/api/projects/status/puw2a1ab4tkcaea3?svg=true)](https://ci.appveyor.com/project/NicholasBlumhardt/serilog-enrichers-demystify)

Unmangle the names of `async` and iterator methods in exception stack traces using @benaadams's [Demystifier](https://github.com/benaadams/Ben.Demystifier).

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

