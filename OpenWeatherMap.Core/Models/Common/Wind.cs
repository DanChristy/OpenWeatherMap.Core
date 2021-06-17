using Newtonsoft.Json;
using OpenWeatherMap.Core.Helpers;

namespace OpenWeatherMap.Core.Models.Common {
	public class Wind {
		[JsonProperty("speed")]
		public double Speed { get; set; }

		[JsonProperty("deg")]
		public int Degrees { get; set; }

		[JsonProperty("gust")]
		public double Gust { get; set; }

		public string WindDirection => CompassHelper.DegToCompass(Degrees);
	}
}