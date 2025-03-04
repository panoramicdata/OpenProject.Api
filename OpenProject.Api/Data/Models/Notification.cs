using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;

/// <summary>
/// Notifications are created through notifiable actions in OpenProject. Notifications are triggered by actions carried out in the system by users, e.g. editing a work package, but can also be send out because of time passing e.g. when a user is notified of a work package that is overdue.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/notifications/'/></para>
/// </summary>
public class Notification : IdentifiedItem<int>
{
	/// <summary>
	/// The subject of the notification	
	/// </summary>
	public string Subject { get; set; } = string.Empty;

	/// <summary>
	/// The reason causing the notification	
	/// </summary>
	public string Reason { get; set; } = string.Empty;

	/// <summary>
	/// Whether the notification is read
	/// </summary>
	[JsonPropertyName("readIAN")]
	public bool IsRead { get; set; }
}
