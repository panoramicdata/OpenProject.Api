namespace OpenProject.Api.Data;

public abstract class IdentifiedItem<T> : IdentifiedItemBase
{
	public required T Id { get; set; }
}