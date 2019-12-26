# Orneholm.SverigesRadio

[![License: MIT](https://img.shields.io/badge/License-MIT-orange.svg)](https://opensource.org/licenses/MIT)
[![Build Status](https://dev.azure.com/orneholm/Orneholm.SverigesRadio/_apis/build/status/Orneholm.SverigesRadio?branchName=master)](https://dev.azure.com/orneholm/Orneholm.SverigesRadio/_build/latest?definitionId=3&branchName=master)
[![NuGet](https://img.shields.io/nuget/v/Orneholm.SverigesRadio.Api.svg)](https://www.nuget.org/packages/Orneholm.SverigesRadio.Api/)
[![Twitter Follow](https://img.shields.io/badge/Twitter-@PeterOrneholm-blue.svg?logo=twitter)](https://twitter.com/PeterOrneholm)

Orneholm.SverigesRadio is an unofficial wrapper of Sveriges Radio Open API (v2) for .NET.

## Features

- :radio: Typed wrappers for the Swedish Radio Open API
- :penguin: Cross platform: Targets .NET Standard 2.0 and .NET Core 3.1
- :arrow_up_down: Supports sorting, filtering, searching etc.

## Supported methods

The API-wrapper supports all these methods:

- Programs
    - `GetProgramAsync(...)`
    - `ListProgramsAsync(...)`
    - `ListProgramNewsAsync(...)`
    - `ListAllProgramsAsync(...)` (See [Pagination with IAsyncEnumerable](#pagination-with-iasyncenumerable))
- ProgramCategories
    - `GetProgramCategoryAsync(...)`
    - `ListProgramCategoriesAsync(...)`
    - `ListAllProgramCategoriesAsync(...)` (See [Pagination with IAsyncEnumerable](#pagination-with-iasyncenumerable))
- Channels
    - `GetChannelAsync(...)`
    - `ListChannelsAsync(...)`
    - `ListAllChannelsAsync(...)` (See [Pagination with IAsyncEnumerable](#pagination-with-iasyncenumerable))
- Episodes
    - `GetEpisodeAsync(...)`
    - `GetEpisodesAsync(...)`
    - `GetLatestEpisodeAsync(...)`
    - `ListEpisodesAsync(...)`
    - `ListAllEpisodesAsync(...)` (See [Pagination with IAsyncEnumerable](#pagination-with-iasyncenumerable))
    - `SearchEpisodesAsync(...)`
    - `SearchAllEpisodesAsync(...)` (See [Pagination with IAsyncEnumerable](#pagination-with-iasyncenumerable))
    - `ListEpisodeNewsAsync(...)`
- EpisodeGroups
    - `ListEpisodeGroupsAsync(...)`
    - `ListAllEpisodeGroupsAsync(...)` (See [Pagination with IAsyncEnumerable](#pagination-with-iasyncenumerable))
- Broadcasts
    - `ListBroadcastsAsync(...)`
    - `ListAllBroadcastsAsync(...)` (See [Pagination with IAsyncEnumerable](#pagination-with-iasyncenumerable))
- Extra broadcasts
    - `ListExtraBroadcastsAsync(...)`
    - `ListAllExtraBroadcastsAsync(...)` (See [Pagination with IAsyncEnumerable](#pagination-with-iasyncenumerable))
- Podfiles
    - `GetPodfileAsync(...)`
    - `ListPodfilesAsync(...)`
    - `ListAllPodfilesAsync(...)` (See [Pagination with IAsyncEnumerable](#pagination-with-iasyncenumerable))
- AudioUrlTemplates
    - `ListOnDemandAudioTypesAsync(...)`
    - `ListLiveAudioTypesAsync(...)`

## Getting started

### 1. Read the documentation

Please start by reading the official documentation to get a basic understanding of the Swedish Radio open API:
https://sverigesradio.se/api/documentation/v2/

### 2. Install the NuGet package

Orneholm.SverigesRadio is distributed as [packages on NuGet](https://www.nuget.org/profiles/PeterOrneholm), install using the tool of your choice, for example _dotnet cli_.

```console
dotnet add package Orneholm.SverigesRadio.Api
```

### 3. Use the API

#### Instantiate the api client

When used in a place where .NET can handle the lifecycle of HttpClient (like ASP.NET), let .NET inject the api client to cache the http client.

```csharp
services.AddHttpClient<ISverigesRadioApiClient, SverigesRadioApiClient>(httpClient =>
{
    httpClient.BaseAddress = SverigesRadioApiDefaults.ProductionApiBaseUrl;
});
```

*Create api client without DI:*

```csharp
var apiClient = SverigesRadioApiClient.CreateClient();
```

*Override default audio settings:*

```csharp
var apiClient = SverigesRadioApiClient.CreateClient(new AudioSettings
{
    OnDemandAudioTemplateId = SverigesRadioApiIds.OnDemandAudioTemplates.Html5_Desktop,
    LiveAudioTemplateId = SverigesRadioApiIds.LiveAudioTemplates.MP3,

    AudioQuality = AudioQuality.High
});
```

#### Get data

##### List programs

```csharp
var programsResult = await apiClient.ListProgramsAsync();
foreach (var program in programsResult.Programs)
{
    Console.WriteLine($"{program.Name} ({program.Id}): {program.Description}");
}
```

##### Get latest episode for P3 Dokumentär

```csharp
var episodeResult = await apiClient.GetLatestEpisodeAsync(SverigesRadioApiIds.Programs.P3_Dokumentar);
Console.WriteLine($"{episodeResult.Episode.Title} ({episodeResult.Episode.Id}): {episodeResult.Episode.Description}");
```

##### List podfiles for Så funkar det (last 3)

```csharp
var podfilesResult = await apiClient.ListPodfilesAsync(SverigesRadioApiIds.Programs.Sa_Funkar_Det, ListPagination.TakeFirst(5));
foreach (var podfile in podfilesResult.Podfiles)
{
    Console.WriteLine($"{podfile.Title} ({podfile.Id}): {podfile.Url}");
}
```

##### Search episodes

```csharp
var episodeSearchResult = await apiClient.SearchEpisodesAsync("Microsoft");
foreach (var episode in episodeSearchResult.Episodes)
{
    Console.WriteLine($"{episode.Title} ({episode.Id}) - {episode.Description}");
}
```

##### More

These were just brief samples. Explore the API to find the rest of the possibilities :)

## Details

### Pagination with IAsyncEnumerable

If used from a runtime that supports .NET Standard 2.1, extensions are provided for the list calls to automatically do pagination using `IAsyncEnumerable`, for example: `ListAllProgramCategoriesAsync()`.
Under the hood the method will fetch 100 items at a time but wllow you to seemlesly enumrate over it.

_Note:_ This will enumerate over all items, which could be millions. Use with care.

### Requests

All methods take a `*Request` object with the parameters for that specific endpoint. There are overloads on all of them for common scenarios. For example:

*Shorthand for search episode:*

```csharp
var episodeSearchResult = await apiClient.SearchEpisodesAsync("Microsoft");
```

*Full request object for search episode:*

```csharp
var episodeSearchResult = await apiClient.SearchEpisodesAsync(new EpisodeSearchRequest("Microsoft")
{
    ChannelId = SverigesRadioApiIds.Channels.P3_Rikskanal
});
```

### Audio settings

You can set the default [audio settings](https://sverigesradio.se/api/documentation/v2/generella_parametrar.html) when creating the API client, but you can also override these settings per method call whemeber audio settings are relevant, like this.

```csharp
var podfilesResult = await apiClient.ListPodfilesAsync(new PodfileListRequest(SverigesRadioApiIds.Programs.Sa_Funkar_Det)
{
    AudioSettings = new AudioSettings()
    {
        AudioQuality = AudioQuality.High,
        OnDemandAudioTemplateId = SverigesRadioApiIds.OnDemandAudioTemplates.M4A_M3U
    }
});
```

### SverigesRadioApiIds constants

Some identifiers in the API are quite constant and there are classes that lists the most common items.

- `SverigesRadioApiIds.Programs`
- `SverigesRadioApiIds.Channels`
- `SverigesRadioApiIds.ChannelTypes`
- `SverigesRadioApiIds.ProgramCategories`
- `SverigesRadioApiIds.OnDemandAudioTemplates`
- `SverigesRadioApiIds.LiveAudioTemplates`

`*Examples:*

- `SverigesRadioApiIds.Programs.Ekot` returns `4540`
- `SverigesRadioApiIds.Channels.P4_Ostergötland_Lokalkanal` returns `222`
- `SverigesRadioApiIds.ChannelTypes.LokalKanal` returns `Lokal kanal`
- `SverigesRadioApiIds.ProgramCategories.Ekonomi` returns `135`
- `SverigesRadioApiIds.OnDemandAudioTemplates.Html5_Desktop` returns `9`
- `SverigesRadioApiIds.LiveAudioTemplates.IOS` returns `12`


---

## Samples & Test

For more use cases, samples and inspiration; feel free to browse our samples and test.

- [Orneholm.SverigesRadio.ConsoleSample](https://github.com/PeterOrneholm/Orneholm.SverigesRadio/tree/master/samples/Orneholm.SverigesRadio.ConsoleSample)
- [Orneholm.SverigesRadio.Api.Test](https://github.com/PeterOrneholm/Orneholm.SverigesRadio/tree/master/test/Orneholm.SverigesRadio.Api.Test)

## Contribute

We are very open to community contributions.
Please see our [contribution guidelines](CONTRIBUTING.md) before getting started.

These methods are missing as of today, feel free to file an issue or provide a PR if you need them:
- Traffic/Messages
- VMA
- Scheduled Episodes
- Playlists

### License & acknowledgements

Orneholm.SverigesRadio is licensed under the very permissive [MIT license](https://opensource.org/licenses/MIT) for you to be able to use it in commercial or non-commercial applications without many restrictions.

The brand Sveriges Radio belongs to Sveriges Radio.
