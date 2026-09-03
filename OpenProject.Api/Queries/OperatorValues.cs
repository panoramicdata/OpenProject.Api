using System.Globalization;

namespace OpenProject.Api.Queries;

/// <summary>
/// Represents a filter operator paired with its values, used to construct API filter expressions.
/// </summary>
public class OperatorValues
{
	/// <summary>
	/// The filter operator to apply.
	/// </summary>
	public required FilterOperator Operator { get; set; }

	/// <summary>
	/// The values to use with the filter operator.
	/// </summary>
	public required List<object?> Values { get; set; }

	/// <summary>
	/// Returns the JSON-encoded operator and values string suitable for use in an API filter expression.
	/// </summary>
	public override string ToString() => $"{{\"operator\":\"{Operator.ToFilterString()}\",\"values\":[{string.Join(",", Values.Select(v => $"\"{GetObjectString(v)}\""))}]}}";

	private static string GetObjectString(object? v)
		=> v switch
		{
			string s => s,
			int i => i.ToString(CultureInfo.InvariantCulture),
			DateTime dt => dt.ToString("yyyy-MM-ddTHH:mm:ddZ", CultureInfo.InvariantCulture),
			bool b => b ? "t" : "f",
			_ => v?.ToString() ?? string.Empty
		};
}
