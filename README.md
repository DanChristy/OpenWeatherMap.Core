# OpenWeatherMap.Core
An asynchronous .NET 5.0 library for interacting with [OpenWeatherMap](https://openweathermap.org/API)

Supports:
* [Current Weather Data](https://openweathermap.org/current)
* [One Call API](https://openweathermap.org/api/one-call-api)

## Setup

### Using Dependency Injection

Add the following to your service collection:
```C#
services.AddOpenWeatherMap("YOUR_ACCESS_KEY");
```
Then just inject `IOpenWeatherMap` to use it.

### Without Dependency Injection
```C#
OpenWeatherMap openWeatherMap = new OpenWeatherMap("YOUR_ACCESS_KEY");
```
### Caching
Caching is built in but disabled by default. To use caching you can specify the amount of time (in seconds) you wish the call to be cached for when initializing `OpenWeatherMap`. The following example will cache the call for 60 seconds.

```C#
new OpenWeatherMap("YOUR_ACCESS_KEY", 60);
```

## Usage

### Current Weather
```c#            
var currentWeatherModel = await openWeatherMap.QueryAsync<CurrentWeatherModel>(40.12, 96.66);              
```

### One Call
```C#
var oneCallWeatherModel = await openWeatherMap.QueryAsync<OneCallWeatherModel>(40.12, 96.66); 
```

### Specifying Units
```C#
var currentWeatherModel = await openWeatherMap.QueryAsync<CurrentWeatherModel>(40.12, 96.66, units: Units.Metric);
```

### Specifying Language
```C#
var currentWeatherModel = await openWeatherMap.QueryAsync<CurrentWeatherModel>(40.12, 96.66, language: Language.Spanish);
```