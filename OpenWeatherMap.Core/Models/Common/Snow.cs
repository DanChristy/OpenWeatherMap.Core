using Newtonsoft.Json;

namespace OpenWeatherMap.Core.Models.Common {
	public class Snow {
		[JsonProperty("1h")]
		public double SnowMillis { get; set; }
	}
}