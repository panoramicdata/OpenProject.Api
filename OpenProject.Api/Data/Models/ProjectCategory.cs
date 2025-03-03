namespace OpenProject.Api.Data.Models;

public class ProjectCategory : IdentifiedItem<string>, INamed
{
	public required string Name { get; set; }
}
