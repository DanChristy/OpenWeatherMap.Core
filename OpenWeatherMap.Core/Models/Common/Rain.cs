using Newtonsoft.Json;

namespace OpenWeatherMap.Core.Models.Common {
	public class Rain {
		[JsonProperty("1h")]
		public double RainMillis1h { get; set; }
		[JsonProperty("3h")]
		public double RainMillis3h { get; set; }
	}
}