namespace OpenProject.Api.Data;

public class WorkPackageType : IdentifiedItem<int>, INamed
{
	public required string Name { get; set; }

	public string Color { get; set; }

	public int Position { get; set; }

	public bool IsDefault { get; set; }

	public bool IsMilestone { get; set; }

}