using Newtonsoft.Json;

namespace OpenWeatherMap.Core.Models.Common {
	public class Rain {
		[JsonProperty("1h")]
		public double RainMillis { get; set; }
	}
}