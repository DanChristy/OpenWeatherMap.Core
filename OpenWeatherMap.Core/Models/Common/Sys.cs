using Newtonsoft.Json;

namespace OpenWeatherMap.Core.Models.Common {
	public class Sys {
		[JsonProperty("pod")]
		public string PeriodOfDay { get; set; }

		[JsonProperty("type")]
		public int Type { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("sunrise")]
		public int Sunrise { get; set; }

		[JsonProperty("sunset")]
		public int Sunset { get; set; }
	}
}