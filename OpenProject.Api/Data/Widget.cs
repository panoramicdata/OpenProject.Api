using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;
/// <summary>
/// A visual widget component placed in an OpenProject grid layout.
/// </summary>
public class Widget
{
	/// <summary>
	/// The widget type designation.
	/// </summary>
	[JsonPropertyName("_type")]
	public required string Type { get; set; }

	/// <summary>
	/// The unique identifier of the widget.
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// The widget identifier string.
	/// </summary>
	public required string Identifier { get; set; }

	/// <summary>
	/// The starting row position in the grid.
	/// </summary>
	public int StartRow { get; set; }

	/// <summary>
	/// The ending row position in the grid.
	/// </summary>
	public int EndRow { get; set; }

	/// <summary>
	/// The starting column position in the grid.
	/// </summary>
	public int StartColumn { get; set; }

	/// <summary>
	/// The ending column position in the grid.
	/// </summary>
	public int EndColumn { get; set; }

	/// <summary>
	/// Widget-specific configuration options.
	/// </summary>
	public Dictionary<string, object> Options { get; set; } = [];
}
