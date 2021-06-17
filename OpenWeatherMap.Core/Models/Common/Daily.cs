using Newtonsoft.Json;
using OpenWeatherMap.Core.Helpers;
using System.Collections.Generic;

namespace OpenWeatherMap.Core.Models.Common {
	public class Daily {
		[JsonProperty("dt")]
		public int Dt { get; set; }

		[JsonProperty("sunrise")]
		public int Sunrise { get; set; }

		[JsonProperty("sunset")]
		public int Sunset { get; set; }

		[JsonProperty("moonrise")]
		public int Moonrise { get; set; }

		[JsonProperty("moonset")]
		public int Moonset { get; set; }

		[JsonProperty("moon_phase")]
		public double MoonPhase { get; set; }

		[JsonProperty("temp")]
		public Temp Temp { get; set; }

		[JsonProperty("feels_like")]
		public FeelsLike FeelsLike { get; set; }

		[JsonProperty("pressure")]
		public int Pressure { get; set; }

		[JsonProperty("humidity")]
		public int Humidity { get; set; }

		[JsonProperty("dew_point")]
		public double DewPoint { get; set; }

		[JsonProperty("wind_speed")]
		public double WindSpeed { get; set; }

		[JsonProperty("wind_deg")]
		public int WindDeg { get; set; }

		[JsonProperty("wind_gust")]
		public double WindGust { get; set; }

		[JsonProperty("weather")]
		public List<Common.Weather> Weather { get; set; }

		[JsonProperty("clouds")]
		public int Clouds { get; set; }

		[JsonProperty("pop")]
		public double Pop { get; set; }

		[JsonProperty("uvi")]
		public double Uvi { get; set; }

		public string WindDirection => CompassHelper.DegToCompass(WindDeg);
	}
}