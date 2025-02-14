namespace OpenProject.Api.Data;

public class Embedded<T> where T : IdentifiedItemBase
{
	public IReadOnlyCollection<T>? Elements { get; set; }

	public ErrorDetails? ErrorDetails { get; set; }
}
