using Newtonsoft.Json;

namespace OpenWeatherMap.Core.Models.Common {
	public class Minutely {
		[JsonProperty("dt")]
		public int Dt { get; set; }

		[JsonProperty("precipitation")]
		public double Precipitation { get; set; }
	}
}