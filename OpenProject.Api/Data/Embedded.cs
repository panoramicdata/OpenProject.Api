namespace OpenProject.Api.Data;

public class Embedded<T> where T : IdentifiedItemBase
{
	public required IReadOnlyCollection<T> Elements { get; set; }
}
