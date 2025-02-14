namespace OpenProject.Api.Data;

public class Embedded<T> where T : IdentifiedItemModelBase
{
	public required IReadOnlyCollection<T> Elements { get; set; }
}
