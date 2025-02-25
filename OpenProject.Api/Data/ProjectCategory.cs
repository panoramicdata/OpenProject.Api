namespace OpenProject.Api.Data;

public class ProjectCategory : IdentifiedItem<string>, INamed
{
	public required string Name { get; set; }
}
