using Newtonsoft.Json;
using OpenWeatherMap.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Core {
	public class BaseHttpClientRequest {
		private readonly HttpClient httpClient;

		public BaseHttpClientRequest() {
			httpClient = new HttpClient();
		}

		public async Task<dynamic> GetAsync<T>(string url, Dictionary<string, string> args, bool getAsBinary = false) {
			HttpContent httpContent = null;

			try {
				if (args != null && args.Any())
					url += "?" + UrlEncodeParams(args);

				using (var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url))) {
					request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					request.Content = httpContent;

					var response = await httpClient.SendAsync(request).ConfigureAwait(false);
					if (!response.IsSuccessStatusCode) {
						var resultAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
						var json = JsonConvert.DeserializeObject<dynamic>(resultAsString);
						WeatherException.ThrowException(url, json);
					}

					if (getAsBinary)
						return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
					else {
						var resultAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
						return JsonConvert.DeserializeObject<T>(resultAsString);
					}
				}
			} finally {
				httpContent?.Dispose();
			}
		}

		private static string UrlEncodeString(string text) {
			return text == null ? "" : Uri.EscapeDataString(text).Replace("%20", "+");
		}

		private static string UrlEncodeParams(Dictionary<string, string> args) {
			var stringBuilder = new StringBuilder();
			var arr = args.Select(x => $"{UrlEncodeString(x.Key)}={UrlEncodeString(x.Value)}").ToArray();

			stringBuilder.Append(string.Join("&", arr));
			return stringBuilder.ToString();
		}
	}
}