namespace OpenProject.Api.Data.Models;

/// <summary>
/// Holds Useful Configuration parameters for the OpenProject Instance
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/configuration/' /></para>
/// </summary>
public class Configuration : ItemBase
{
	/// <summary>
	/// The maximum allowed size of an attachment in Bytes	
	/// </summary>
	public int MaximumAttachmentFileSize { get; set; }

	/// <summary>
	/// Page size steps to be offered in paginated list UI	
	/// </summary>
	public IEnumerable<int> PerPageOptions { get; set; } = [];

	/// <summary>
	/// The host name configured for the system	
	/// </summary>
	public string HostName { get; set; } = string.Empty;

	/// <summary>
	/// The format used to display Work, Remaining Work, and Spent time durations.	
	/// </summary>
	public string DurationFormat { get; set; } = string.Empty;

	/// <summary>
	/// The list of all feature flags that are active	
	/// </summary>
	public IEnumerable<string> ActiveFeatureFlags { get; set; } = [];
}
