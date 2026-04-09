namespace OpenProject.Api.Enums;

/// <summary>
/// Which highlighting mode should the table have?	
/// </summary>
public enum HighlightingMode
{
	/// <summary>
	/// No highlighting applied.
	/// </summary>
	None,

	/// <summary>
	/// Inline highlighting within the table row.
	/// </summary>
	Inline,

	/// <summary>
	/// Highlight by work package status.
	/// </summary>
	Status,

	/// <summary>
	/// Highlight by work package priority.
	/// </summary>
	Priority,

	/// <summary>
	/// Highlight by work package type.
	/// </summary>
	Type
}
