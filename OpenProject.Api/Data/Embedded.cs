namespace OpenProject.Api.Data;

public class Embedded<T> where T : ItemModel
{
	public required IReadOnlyCollection<T> Elements { get; set; }
}
