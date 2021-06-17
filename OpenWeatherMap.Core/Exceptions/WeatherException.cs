using System;
using System.Runtime.Serialization;

namespace OpenWeatherMap.Core.Exceptions {
	[Serializable]
	public class WeatherException : Exception {
		public string RequestMethod { get; }
		public dynamic DataJson { get; private set; }

		public WeatherException() { }

		public WeatherException(string message, Exception innerException) : base(message, innerException) { }

		public WeatherException(string message) : base(message) { }

		public WeatherException(string callerMethod, string message) : base(message) {
			RequestMethod = callerMethod;
		}

		public static void ThrowException(string callerMethod, dynamic json) {
			throw new WeatherException(callerMethod, FormatMessage(callerMethod, json)) {
				DataJson = json
			}; ;
		}

		private static string FormatMessage(string callerMethod, dynamic json) {
			if (json == null)
				return $"Failed request {callerMethod}. Message: Null";

			return $"Failed request {callerMethod}. Message: {(string)json.message}. Error Code: {(int)json.cod}.";
		}

		protected WeatherException(SerializationInfo serializationInfo, StreamingContext streamingContext)
			: base(serializationInfo, streamingContext) {
		}
	}
}