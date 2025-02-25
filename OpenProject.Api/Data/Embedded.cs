namespace OpenProject.Api.Data;

public class Embedded<T> where T : ItemBase
{
	public IReadOnlyCollection<T>? Elements { get; set; }

	public ErrorDetails? ErrorDetails { get; set; }
}
