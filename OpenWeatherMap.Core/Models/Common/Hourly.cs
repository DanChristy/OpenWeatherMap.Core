using Newtonsoft.Json;
using OpenWeatherMap.Core.Helpers;
using System.Collections.Generic;

namespace OpenWeatherMap.Core.Models.Common {
	public class Hourly {
		[JsonProperty("dt")]
		public int Dt { get; set; }

		[JsonProperty("main")]
		public Main Main { get; set; }

		[JsonProperty("temp")]
		public double Temp { get; set; }

		[JsonProperty("feels_like")]
		public double FeelsLike { get; set; }

		[JsonProperty("pressure")]
		public int Pressure { get; set; }

		[JsonProperty("humidity")]
		public int Humidity { get; set; }

		[JsonProperty("dew_point")]
		public double DewPoint { get; set; }

		[JsonProperty("uvi")]
		public double Uvi { get; set; }

		[JsonProperty("clouds")]
		public int Clouds { get; set; }

		[JsonProperty("visibility")]
		public int Visibility { get; set; }

		[JsonProperty("wind")]
		public Wind Wind { get; set; }

		[JsonProperty("wind_speed")]
		public double WindSpeed { get; set; }

		[JsonProperty("wind_deg")]
		public int WindDeg { get; set; }

		[JsonProperty("wind_gust")]
		public double WindGust { get; set; }

		[JsonProperty("rain")]
		public Rain Rain { get; set; }

		[JsonProperty("snow")]
		public Snow Snow { get; set; }

		[JsonProperty("weather")]
		public List<Weather> Weather { get; set; }

		[JsonProperty("pop")]
		public double Pop { get; set; }

		[JsonProperty("sys")]
		public Sys Sys { get; set; }

		[JsonProperty("dt_txt")]
		public string DtTxt { get; set; }

		public string WindDirection => CompassHelper.DegToCompass(WindDeg);
	}
}