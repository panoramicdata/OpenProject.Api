namespace OpenProject.Api.Data;

public abstract class NamedIdentifiedItem<T> : IdentifiedItem<T>
{
	public required string Name { get; set; }
}