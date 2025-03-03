﻿using System.Collections;
using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;

public class Query : IdentifiedItem<int>, INamed, IHasTimestamps
{
	[JsonPropertyName("starred")]
	public bool IsStarred { get; set; }

	public string Name { get; set; } = string.Empty;

	public IEnumerable<Filter> Filters { get; set; } = [];

	public bool IncludeSubProjects { get; set; }

	public bool Sums { get; set; }

	[JsonPropertyName("public")]
	public bool IsPublic { get; set; }

	[JsonPropertyName("hidden")]
	public bool IsHidden { get; set; }

	public bool TimelineVisible { get; set; }

	public bool ShowHierarchies { get; set; }

	public string TimelineZoomLevel { get; set; } = string.Empty;

	public IDictionary TimelineLables { get; set; }

	public IEnumerable<string> Timestamps { get; set; } = [];

	public string HighlightingMode { get; set; } = string.Empty;

	public DateTime CreatedAt { get; set; }

	public DateTime UpdatedAt { get; set; }
}
