using OpenProject.Api.Data.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Type = System.Type;

namespace OpenProject.Api.Data;

/// <summary>
/// Reads and writes <see cref="IHasSchedule"/> models with their <see cref="WorkPackageSchedule"/> fields at the
/// top level of the JSON object, where OpenProject puts them.
/// </summary>
internal sealed class FlatScheduleConverterFactory : JsonConverterFactory
{
	public override bool CanConvert(Type typeToConvert)
		=> typeToConvert.IsClass && typeof(IHasSchedule).IsAssignableFrom(typeToConvert);

	public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
		=> (JsonConverter)Activator.CreateInstance(
			typeof(FlatScheduleConverter<>).MakeGenericType(typeToConvert),
			WithoutThisFactory(options))!;

	// Without this, serializing the model inside the converter would re-enter the converter.
	private static JsonSerializerOptions WithoutThisFactory(JsonSerializerOptions options)
	{
		var inner = new JsonSerializerOptions(options);
		for (var i = inner.Converters.Count - 1; i >= 0; i--)
		{
			if (inner.Converters[i] is FlatScheduleConverterFactory)
			{
				inner.Converters.RemoveAt(i);
			}
		}

		return inner;
	}

	private sealed class FlatScheduleConverter<T>(JsonSerializerOptions inner) : JsonConverter<T>
		where T : class, IHasSchedule
	{
		public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			using var document = JsonDocument.ParseValue(ref reader);
			var item = document.RootElement.Deserialize<T>(inner);
			if (item is not null)
			{
				item.Schedule = document.RootElement.Deserialize<WorkPackageSchedule>(inner) ?? new();
			}

			return item;
		}

		public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
		{
			var node = JsonSerializer.SerializeToNode(value, inner)!.AsObject();
			foreach (var (name, field) in JsonSerializer.SerializeToNode(value.Schedule, inner)!.AsObject())
			{
				node[name] = field?.DeepClone();
			}

			node.WriteTo(writer, inner);
		}
	}
}
