using OpenProject.Api.Enums;
using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models.Create;

/// <summary>
/// Represents an object used to create a new User on the OpenProject Instance
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/users/'/></para>
/// </summary>
public class UserCreate
{
	/// <summary>
	/// User’s login name	
	/// </summary>
	[StringLength(256)]
	public required string Login { get; set; }

	/// <summary>
	/// User’s password for the default password authentication	
	/// </summary>
	public required string Password { get; set; }

	/// <summary>
	/// User’s first name
	/// </summary>
	[StringLength(30)]
	public required string FirstName { get; set; }

	/// <summary>
	/// User’s last name
	/// </summary>
	[StringLength(30)]
	public required string LastName { get; set; }

	/// <summary>
	/// User’s email address
	/// </summary>
	[StringLength(60)]
	public required string Email { get; set; }

	/// <summary>
	/// Flag indicating whether or not the user is an admin
	/// </summary>
	[JsonPropertyName("admin")]
	public required bool IsAdmin { get; set; }

	/// <summary>
	/// The current activation status of the user (see below)
	/// </summary>
	public required UserStatus Status { get; set; }

	/// <summary>
	/// User’s language
	/// </summary>
	public required string Language { get; set; }
}
