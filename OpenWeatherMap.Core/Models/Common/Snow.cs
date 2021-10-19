using Newtonsoft.Json;

namespace OpenWeatherMap.Core.Models.Common {
	public class Snow {
		[JsonProperty("1h")]
		public double SnowMillis1h { get; set; }
		[JsonProperty("3h")]
		public double SnowMillis3h { get; set; }
	}
}