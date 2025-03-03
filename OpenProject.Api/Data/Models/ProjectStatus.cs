namespace OpenProject.Api.Data.Models;

/// <summary>
/// ProjectStatusModel
/// </summary>
public class ProjectStatus : IdentifiedItem<string>, INamed
{
	public string Name { get; set; } = string.Empty;
}
