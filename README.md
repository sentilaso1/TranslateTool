# GameTranslator

This repository provides a skeleton for a real-time game translation tool written in **C#** using WPF and the MVVM architecture. The solution includes separate projects for the application UI, core interfaces, infrastructure services, and unit tests.

## Projects
- **GameTranslator.App** - WPF front-end application.
- **GameTranslator.Core** - Core abstractions and models.
- **GameTranslator.Infrastructure** - Implementations for translation, OCR, and caching with dependency injection helpers.
- **GameTranslator.Tests** - Example unit tests using xUnit and Moq.

## Build
```bash
# Restore dependencies
 dotnet restore GameTranslator.sln
# Run tests
 dotnet test GameTranslator.sln
```

The solution targets **.NET 8**. WPF applications require Windows to run; building on non-Windows hosts may need the Windows desktop SDK.
