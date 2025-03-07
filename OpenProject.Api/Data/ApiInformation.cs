namespace OpenProject.Api.Data;
/// <summary>
/// Stores information about the OpenProject instance
/// </summary>
public class ApiInformation : ItemBase
{
	/// <summary>
	/// The name of the OpenProject instance
	/// </summary>
	public required string InstanceName { get; set; }

	/// <summary>
	/// The OpenProject core version number for the instance	
	/// </summary>
	public required string CoreVersion { get; set; }
}
