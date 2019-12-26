# Orneholm.SverigesRadio.API

Orneholm.SverigesRadio is an unofficial wrapper of Sveriges Radio Open API (v2) for .NET.

### 1. Read the documentation

Please start by reading the official documentation to get a basic understanding of the Swedish Radio open API:
https://sverigesradio.se/api/documentation/v2/

### 2. Install the NuGet package

Orneholm.SverigesRadio is distributed as [packages on NuGet](https://www.nuget.org/profiles/PeterOrneholm), install using the tool of your choice, for example _dotnet cli_.

```console
dotnet add package Orneholm.SverigesRadio.Api
```

### 3. Use the API

Simple sample listing 10 programs.

```csharp
var apiClient = SverigesRadioApiClient.CreateClient();

var programsResult = await apiClient.ListProgramsAsync();
foreach (var program in programsResult.Programs)
{
    Console.WriteLine($"{program.Name} ({program.Id}): {program.Description}");
}
```

For full documentation, go to the GitHub repository:
https://github.com/PeterOrneholm/Orneholm.SverigesRadio
