
namespace OpenProject.Api.Data.Models;

/// <summary>
/// Work package types represented in the system.
/// Types exist globally and are then activated for projects.
/// <para><a href='https://www.openproject.org/docs/api/endpoints/types/'/></para>
/// </summary>
public class Type : IdentifiedItem<int>, INamed, IHasTimestamps
{
	/// <summary>
	/// Type Name
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// The color used to represent this type	
	/// </summary>
	public string Color { get; set; } = string.Empty;

	/// <summary>
	/// Sort index of the type	
	/// </summary>
	public int Position { get; set; }

	/// <summary>
	/// Is this type active by default in new projects?	
	/// </summary>
	public bool IsDefault { get; set; }

	/// <summary>
	/// Do work packages of this type represent a milestone?	
	/// </summary>
	public bool IsMilestone { get; set; }

	/// <summary>
	/// Time of creation
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// Time of creation
	/// </summary>
	public DateTime UpdatedAt { get; set; }
}