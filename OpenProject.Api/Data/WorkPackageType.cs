namespace OpenProject.Api.Data;

public class WorkPackageType : NamedIdentifiedItem<int>
{
	public string Color { get; set; }
	public int Position { get; set; }
	public bool IsDefault { get; set; }
	public bool IsMilestone { get; set; }
}