using OpenProject.Api.Enums;
using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;

/// <summary>
/// The fields accepted when writing a User to the OpenProject Instance.
/// <para>Shared by <see cref="Create.UserCreate"/> and <see cref="Update.UserUpdate"/>, which
/// accept exactly the same fields; the two remain distinct types so that each endpoint keeps
/// its own name at the call site.</para>
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/users/'/></para>
/// </summary>
public abstract class UserWrite
{
	/// <summary>
	/// User's login name
	/// </summary>
	[StringLength(256, MinimumLength = 1)]
	public required string Login { get; set; }

	/// <summary>
	/// User's password for the default password authentication
	/// </summary>
	public required string Password { get; set; }

	/// <summary>
	/// User's first name
	/// </summary>
	[StringLength(30, MinimumLength = 1)]
	public required string FirstName { get; set; }

	/// <summary>
	/// User's last name
	/// </summary>
	[StringLength(30, MinimumLength = 1)]
	public required string LastName { get; set; }

	/// <summary>
	/// User's email address
	/// </summary>
	[StringLength(60)]
	[EmailAddress]
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
	/// User's language (ISO 639-1 Format)
	/// </summary>
	[StringLength(3, MinimumLength = 2)]
	public required string Language { get; set; }
}