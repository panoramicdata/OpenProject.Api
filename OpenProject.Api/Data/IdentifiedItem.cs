namespace OpenProject.Api.Data;

/// <summary>
/// Represents an identified item with a unique identifier and additional metadata.
/// Inherits from <see cref="IdentifiedItemBase"/>.
/// </summary>
/// <remarks>
/// Properties:
/// <list type="bullet">
/// <item>
/// <description><see cref="IdentifiedItemBase.Type"/>: The type of the item.</description>
/// </item>
/// <item>
/// <description><see cref="IdentifiedItemBase.CreatedAt"/>: The creation date and time of the item.</description>
/// </item>
/// <item>
/// <description><see cref="IdentifiedItemBase.UpdatedAt"/>: The last update date and time of the item.</description>
/// </item>
/// <item>
/// <description><see cref="IdentifiedItemBase.Links"/>: The links associated with the item.</description>
/// </item>
/// <item>
/// <description><see cref="Id"/>: The unique identifier of the item.</description>
/// </item>
/// </list>
/// </remarks>
public abstract class IdentifiedItem<T> : IdentifiedItemBase
{
	public required T Id { get; set; }
}
