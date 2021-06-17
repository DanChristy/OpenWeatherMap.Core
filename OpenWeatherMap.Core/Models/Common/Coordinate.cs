using Newtonsoft.Json;

namespace OpenWeatherMap.Core.Models.Common {
	public class Coordinate {
		[JsonProperty("lat")]
		public double Lat { get; set; }

		[JsonProperty("lon")]
		public double Lon { get; set; }
	}
}