using System;
using System.Security.Claims;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SILClient.Models.Class;

public class ClaimsConverter : JsonConverter
{
	public override bool CanWrite => false;

	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(Claim);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		JObject jObject = JObject.Load(reader);
		string type = (string)jObject["m_type"];
		string value = (string)jObject["m_value"];
		string valueType = (string)jObject["m_valueType"];
		string issuer = (string)jObject["m_issuer"];
		string originalIssuer = (string)jObject["m_originalIssuer"];
		return new Claim(type, value, valueType, issuer, originalIssuer);
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		throw new NotImplementedException();
	}
}
