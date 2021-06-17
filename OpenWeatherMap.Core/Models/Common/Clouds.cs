using Newtonsoft.Json;

namespace OpenWeatherMap.Core.Models.Common {
	public class Clouds {
		[JsonProperty("all")]
		public int All { get; set; }
	}
}