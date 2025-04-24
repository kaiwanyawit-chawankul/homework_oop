using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace homework_oop;

public class UnitTest2
{
    public class A
    {
        public string Type { get; set; }
    }

    public class B : A
    {
        public string AdditionalProperty { get; set; }
    }

	public abstract class JsonCreationConverter<T> : JsonConverter
	{
		/// <summary>
		/// Create an instance of objectType, based properties in the JSON object
		/// </summary>
		/// <param name="objectType">type of object expected</param>
		/// <param name="jObject">contents of JSON object that will be deserialized</param>
		/// <returns></returns>
		protected abstract T Create(Type objectType, JObject jObject);

		public override bool CanConvert(Type objectType)
		{
			return typeof(T).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			// Load JObject from stream
			JObject jObject = JObject.Load(reader);

			// Create target object based on JObject
			T target = Create(objectType, jObject);

			// Populate the object properties
			serializer.Populate(jObject.CreateReader(), target);

			return target;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}

	public class AConverter : JsonCreationConverter<A>
	{
		protected override A Create(Type objectType, JObject jObject)
		{
			if (FieldExists("AdditionalProperty" , jObject))
			{
				return new B();
			}

			return new A();
		}

		private bool FieldExists(string fieldName, JObject jObject)
		{
			return jObject[fieldName] != null;
		}
	}


    [Fact]
    public void ConvertDerivedClassFromJsonList()
    {
        // Given
        string json = "[{\"Type\":\"A\"},{\"Type\":\"B\",\"AdditionalProperty\":\"Value\"}]";
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Converters = new List<JsonConverter> { new AConverter() }
        };
        // When
        var result = JsonConvert.DeserializeObject<List<A>>(json, settings);
        // Then
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("A", result[0].Type);
        Assert.Equal("B", result[1].Type);
        Assert.Equal("Value", (result[1] as B).AdditionalProperty);
    }
}
