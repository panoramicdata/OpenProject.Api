namespace OpenProject.Api.Data;

public abstract class IdentifiedItemModel<T> : IdentifiedItemModelBase
{
	public required T Id { get; set; }
}