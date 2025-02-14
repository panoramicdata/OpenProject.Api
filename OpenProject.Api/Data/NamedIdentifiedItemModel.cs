namespace OpenProject.Api.Data;

public abstract class NamedIdentifiedItemModel<T> : IdentifiedItemModel<T>
{
	public required string Name { get; set; }
}