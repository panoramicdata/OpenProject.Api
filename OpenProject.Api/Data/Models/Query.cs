using System.Collections;
using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;

/// <summary>
/// A query defines how work packages can be filtered and displayed. Clients can define a query once, store it, and use it later on to load the same set of filters and display options.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/queries/'/></para>
/// </summary>
public class Query : IdentifiedItem<int>, INamed, IHasTimestamps
{
	/// <summary>
	/// Query name
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// A set of QueryFilters which will be applied to the work packages to determine the resulting work packages
	/// </summary>
	public IEnumerable<Filter> Filters { get; set; } = [];

	/// <summary>
	/// Should sums (of supported properties) be shown?
	/// </summary>
	[JsonPropertyName("sums")]
	public bool ShowSums { get; set; }

	/// <summary>
	/// Should the timeline mode be shown?
	/// </summary>
	[JsonPropertyName("timelineVisible")]
	public bool IsTimelineVisible { get; set; }

	/// <summary>
	/// Which labels are shown in the timeline, empty when default
	/// </summary>
	public IDictionary TimelineLabels { get; set; }

	/// <summary>
	/// Which zoom level should the timeline be rendered in?
	/// </summary>
	public string TimelineZoomLevel { get; set; } = string.Empty;

	/// <summary>
	/// The timestamps to filter by when showing changed attributes on work packages.
	/// </summary>
	public IEnumerable<string> Timestamps { get; set; } = [];

	/// <summary>
	/// Which highlighting mode should the table have?	
	/// </summary>
	public string HighlightingMode { get; set; } = string.Empty;

	/// <summary>
	/// Should the hierarchy mode be enabled?
	/// </summary>
	public bool ShowHierarchies { get; set; }

	/// <summary>
	/// Should the query be hidden from the query list?
	/// </summary>
	[JsonPropertyName("hidden")]
	public bool IsHidden { get; set; }

	/// <summary>
	/// Can users besides the owner see the query?
	/// </summary>
	[JsonPropertyName("public")]
	public bool IsPublic { get; set; }

	/// <summary>
	/// Should the query be highlighted to the user?
	/// </summary>
	[JsonPropertyName("starred")]
	public bool IsStarred { get; set; }

	/// <summary>
	/// Time of creation
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// Time of the most recent change to the query	
	/// </summary>
	public DateTime UpdatedAt { get; set; }
}
