using System.Collections;
using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;
public class Query : IdentifiedItem<int>
{
	[JsonPropertyName("starred")]
	public bool IsStarred { get; set; }

	public string Name { get; set; }

	public IEnumerable<Filter> Filters { get; set; }

	public bool IncludeSubProjects { get; set; }
	public bool Sums { get; set; }

	[JsonPropertyName("public")]
	public bool IsPublic { get; set; }

	[JsonPropertyName("hidden")]
	public bool IsHidden { get; set; }

	public bool TimelineVisible { get; set; }

	public bool ShowHierarchies { get; set; }

	public string TimelineZoomLevel { get; set; }

	public IDictionary TimelineLables { get; set; }

	public IEnumerable<string> Timestamps { get; set; } = [];

	public string HighlightingMode { get; set; }
}
