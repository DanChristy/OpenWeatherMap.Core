using Microsoft.Extensions.DependencyInjection;
using OpenWeatherMap.Core.Interfaces;

namespace OpenWeatherMap.Core.Extensions {
	public static class AppServices {
		public static void AddOpenWeatherMap(this IServiceCollection services, string apiKey, int? expiration = null) {
			services.AddSingleton<IOpenWeatherMap>(new OpenWeatherMap(apiKey, expiration));
		}
	}
}