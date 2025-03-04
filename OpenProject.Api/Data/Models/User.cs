using OpenProject.Api.Enums;
using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;

/// <summary>
/// Represents a person (described by an identifier) who uses OpenProject. Users can become project members by assigning them a role and adding them via the project settings..
/// see <para><a href='https://www.openproject.org/docs/system-admin-guide/users-permissions/users/'/></para>
/// </summary>
public class User : IdentifiedItem<int>, INamed, IHasTimestamps
{
	/// <summary>
	/// User’s login name
	/// </summary>
	[MaxLength(256)]
	public required string Login { get; set; }

	/// <summary>
	/// User’s first name
	/// </summary>
	[MaxLength(30)]
	public required string FirstName { get; set; }

	/// <summary>
	/// User’s last name
	/// </summary>
	[MaxLength(30)]
	public required string LastName { get; set; }

	/// <summary>
	/// User’s full name, formatting depends on instance settings
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// User’s email address
	/// </summary>
	public required string Email { get; set; }

	/// <summary>
	/// Flag indicating whether the user is an admin
	/// </summary>
	[JsonPropertyName("admin")]
	public bool IsAdmin { get; set; }

	/// <summary>
	/// URL to user’s avatar	
	/// </summary>
	public required string Avatar { get; set; }

	/// <summary>
	/// The current activation status of the user (see below)
	/// </summary>
	public required UserStatus Status { get; set; }

	/// <summary>
	/// User’s language (ISO 639-1 Format)
	/// </summary>
	public required string Language { get; set; }

	/// <summary>
	/// User’s password for the default password authentication
	/// </summary>
	public string Password { get; set; } = string.Empty;

	/// <summary>
	/// User’s identity_url for OmniAuth authentication
	/// </summary>
	public required string IdentityUrl { get; set; }

	/// <summary>
	/// Time of creation
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// Time of the most recent change to the user
	/// </summary>
	public DateTime UpdatedAt { get; set; }
}