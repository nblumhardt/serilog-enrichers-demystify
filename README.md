# Serilog.Enrichers.Demystify [![NuGet Pre Release](https://img.shields.io/nuget/vpre/serilog.enrichers.demystify.svg)](https://www.nuget.org/packages/serilog.enrichers.demystify) [![Build status](https://ci.appveyor.com/api/projects/status/puw2a1ab4tkcaea3?svg=true)](https://ci.appveyor.com/project/NicholasBlumhardt/serilog-enrichers-demystify)

> **Important note:** This package is no longer being actively developed, as the improved stack trace functionality is now a part of .NET Core, and thus the future utility of this integration package is limited. If you'd like to take over development, please feel free to fork, or contact @nblumhardt.

Unmangle the names of `async` and iterator methods in exception stack traces using @benaadams's [Demystifier](https://github.com/benaadams/Ben.Demystifier).

### Getting started

Install from NuGet:

```
Install-Package Serilog.Enrichers.Demystify -Pre -DependencyVersion Highest
```

Configure log event enrichment:

```csharp
Log.Logger = new LoggerConfiguration()
    .Enrich.WithDemystifiedStackTraces() // <- Add this line
    .WriteTo.Console()
    .CreateLogger();
```

The enricher will replace logged exception stack traces with unmangled ones.

