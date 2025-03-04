using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Notifications are created through notifiable actions in OpenProject. Notifications are triggered by actions carried out in the system by users, e.g. editing a work package, but can also be send out because of time passing e.g. when a user is notified of a work package that is overdue.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/notifications/'/></para>
/// </summary>
public interface INotifications
{
	/// <summary>
	/// Get all Notifications
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/notifications")]
	Task<OpenProjectItemSet<Notification>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get Notification by ID
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/notifications/{id}")]
	Task<Notification> GetAsync(
		int id,
		CancellationToken cancellationToken);
}
