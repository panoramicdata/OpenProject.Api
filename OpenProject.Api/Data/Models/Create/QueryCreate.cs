using OpenProject.Api.Enums;
using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models.Create;

/// <summary>
/// Represents an object used to create a new Query on the OpenProject Instance
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/queries/'/></para>
/// </summary>
public class QueryCreate
{
	/// <summary>
	/// The Name of the new Query
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// A set of QueryFilters which will be applied to the work packages to determine the resulting work packages
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public IEnumerable<QueryFilterInstance>? Filters { get; set; }

	/// <summary>
	/// Should sums (of supported properties) be shown?	
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	[JsonPropertyName("sums")]
	public bool? ShowSums { get; set; }

	/// <summary>
	/// Should the timeline mode be shown?	
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	[JsonPropertyName("timelineVisible")]
	public bool? IsTimelineVisible { get; set; }

	// Todo: Add Timeline Labels

	/// <inheritdoc cref="ZoomLevel"/>
	public ZoomLevel TimelineZoomLevel { get; set; }

	/// <summary>
	/// The timestamps to filter by when showing changed attributes on work packages.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public IEnumerable<string>? Timestamps { get; set; }

	/// <summary>
	/// Which highlighting mode should the table have?	
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public HighlightingMode? HighlightingMode { get; set; }

	/// <summary>
	/// Should the hierarchy mode be enabled?	
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? ShowHierarchies { get; set; }

	/// <summary>
	/// Should the query be hidden from the query list?	
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	[JsonPropertyName("hidden")]
	public bool? IsHidden { get; set; }

	/// <summary>
	/// Can users besides the owner see the query?	
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	[JsonPropertyName("public")]
	public bool? IsPublic { get; set; }
}
