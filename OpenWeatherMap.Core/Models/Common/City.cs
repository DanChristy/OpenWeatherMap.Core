using Newtonsoft.Json;
using System;

namespace OpenWeatherMap.Core.Models.Common {
	public class City {
		[JsonProperty("id")]
		public UInt64 Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("coord")]
		public Coordinate Coord { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("population")]
		public UInt64 Population { get; set; }

		[JsonProperty("timezone")]
		public int TimezoneOffset { get; set; }

		[JsonProperty("sunrise")]
		public long Sunrise { get; set; }

		[JsonProperty("sunset")]
		public long Sunset { get; set; }
	}
}