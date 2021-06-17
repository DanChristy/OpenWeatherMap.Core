using Newtonsoft.Json;

namespace OpenWeatherMap.Core.Models.Common {
	public class Main {
		[JsonProperty("temp")]
		public double Temp { get; set; }

		[JsonProperty("feels_like")]
		public double FeelsLike { get; set; }

		[JsonProperty("temp_min")]
		public double TempMin { get; set; }

		[JsonProperty("TempMax")]
		public double TempMax { get; set; }

		[JsonProperty("pressure")]
		public int Pressure { get; set; }

		[JsonProperty("sea_level")]
		public int SeaLevelPressure { get; set; }

		[JsonProperty("grnd_level")]
		public int GroundLevelPressure { get; set; }

		[JsonProperty("humidity")]
		public int Humidity { get; set; }

		[JsonProperty("temp_kf")]
		public double TempKf { get; set; }
	}
}