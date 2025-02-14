using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;

public class User : NamedIdentifiedItem<int>
{
	public required string Login { get; set; }

	[JsonPropertyName("admin")]
	public bool IsAdmin { get; set; }

	public required string FirstName { get; set; }

	public required string LastName { get; set; }

	public required string Email { get; set; }

	public required string Avatar { get; set; }

	public required string Status { get; set; }

	public required object IdentityUrl { get; set; }

	public required string Language { get; set; }
}