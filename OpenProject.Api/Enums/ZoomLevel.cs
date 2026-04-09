namespace OpenProject.Api.Enums;

/// <summary>
/// Which zoom level should the timeline be rendered in?	
/// </summary>
public enum ZoomLevel
{
	/// <summary>
	/// Daily granularity.
	/// </summary>
	Days,

	/// <summary>
	/// Weekly granularity.
	/// </summary>
	Weeks,

	/// <summary>
	/// Monthly granularity.
	/// </summary>
	Months,

	/// <summary>
	/// Quarterly granularity.
	/// </summary>
	Quarters,

	/// <summary>
	/// Yearly granularity.
	/// </summary>
	Years
}
