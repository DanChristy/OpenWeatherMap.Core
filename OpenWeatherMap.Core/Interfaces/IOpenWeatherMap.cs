using OpenWeatherMap.Core.Enums;
using System.Threading.Tasks;

namespace OpenWeatherMap.Core.Interfaces {
	public interface IOpenWeatherMap {
		Task<T> QueryAsync<T>(double lat, double lon, Language language = Language.English, Units units = Units.Imperial, string version = "2.5");
		Task<T> QueryAsync<T>(string cityName, Language language = Language.English, Units units = Units.Imperial, string version = "2.5");
	}
}