namespace OpenProject.Api.Data;

public abstract class NamedItemModel : ItemModel
{
	public required string Name { get; set; }
}