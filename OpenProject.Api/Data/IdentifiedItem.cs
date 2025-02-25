namespace OpenProject.Api.Data;

/// <summary>
/// Represents an identified item with a unique identifier and additional metadata.
/// Inherits from <see cref="ItemBase"/>.
/// </summary>
/// <remarks>
/// Properties:
/// <list type="bullet">
/// <item>
/// <description><see cref="ItemBase.Type"/>: The type of the item.</description>
/// </item>
/// <item>
/// <description><see cref="ItemBase.Links"/>: The links associated with the item.</description>
/// </item>
/// <item>
/// <description><see cref="Id"/>: The unique identifier of the item.</description>
/// </item>
/// </list>
/// </remarks>
public abstract class IdentifiedItem<T> : ItemBase
{
	public required T Id { get; set; }
}
