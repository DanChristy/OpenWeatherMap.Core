using OpenWeatherMap.Core.Enums;
using OpenWeatherMap.Core.Interfaces;
using OpenWeatherMap.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace OpenWeatherMap.Core {
	public class OpenWeatherMap : BaseHttpClientRequest, IOpenWeatherMap {
		public readonly string BaseUrl = "https://api.openweathermap.org/data";
		private readonly string apiKey;
		private readonly int? expiration;
		private readonly MemoryCache cache;
		private Dictionary<string, string> argumentDictionary { get; set; }

		/// <summary>
		/// Initialization of the OpenWeatherMap.
		/// </summary>
		/// <param name="apiKey">The API key for https://openweathermap.org/api. </param>
		/// <param name="expiration">The time in seconds that the call should be cached for.</param>
		public OpenWeatherMap(string apiKey, int? expiration = null) {
			this.apiKey = apiKey;
			this.expiration = expiration;

			if (expiration != null)
				cache = MemoryCache.Default;
		}

		public async Task<T> QueryAsync<T>(double lat, double lon, Language language = Language.English, Units units = Units.Imperial, string version = "2.5") {
			var request = $"{lat}{lon}{language}{units}";

			dynamic response = null;

			if (cache != null) {
				response = cache.Get(request);
			}

			if (response is null) {
				argumentDictionary = new Dictionary<string, string> {
					{"appid", apiKey.ToString(CultureInfo.InvariantCulture)},
					{"lat", lat.ToString(CultureInfo.InvariantCulture)},
					{"lon", lon.ToString(CultureInfo.InvariantCulture)},
					{"lang", (language.GetType().GetMember(language.ToString()).First().GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute).Description},
					{"units", units.ToString()}
				};

				string url;

				switch (typeof(T)) {
					case var currentWeatherModel when currentWeatherModel == typeof(CurrentWeatherModel):
						url = $"{BaseUrl}/{version}/weather";
						break;
					case var oneCallWeatherModel when oneCallWeatherModel == typeof(OneCallWeatherModel):
						url = $"{BaseUrl}/{version}/onecall";
						break;
					default:
						url = "";
						break;
				}

				response = await GetAsync<T>(url, argumentDictionary);

				if (cache != null) {
					var policy = new CacheItemPolicy {
						AbsoluteExpiration = DateTime.Now.AddSeconds(expiration.Value)
					};

					cache.Set(request, response, policy);
				}
			}

			return response;
		}

		public async Task<T> QueryAsync<T>(string cityName, Language language = Language.English, Units units = Units.Imperial, string version = "2.5")
		{
			var request = $"{cityName}{language}{units}";

			dynamic response = null;

			if (cache != null)
			{
				response = cache.Get(request);
			}

			if (response is null)
			{
				argumentDictionary = new Dictionary<string, string> {
					{"appid", apiKey.ToString(CultureInfo.InvariantCulture)},
					{"q", cityName},
					{"lang", (language.GetType().GetMember(language.ToString()).First().GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute).Description},
					{"units", units.ToString()}
				};

				string url;

				switch (typeof(T))
				{
					case var currentWeatherModel when currentWeatherModel == typeof(CurrentWeatherModel):
						url = $"{BaseUrl}/{version}/weather";
						break;
					case var oneCallWeatherModel when oneCallWeatherModel == typeof(OneCallWeatherModel):
						url = $"{BaseUrl}/{version}/onecall";
						break;
					default:
						url = "";
						break;
				}

				response = await GetAsync<T>(url, argumentDictionary);

				if (cache != null)
				{
					var policy = new CacheItemPolicy
					{
						AbsoluteExpiration = DateTime.Now.AddSeconds(expiration.Value)
					};

					cache.Set(request, response, policy);
				}
			}

			return response;
		}
	}
}