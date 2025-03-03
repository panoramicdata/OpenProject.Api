using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Statuses are used to differentiate Work Packages, filter, and group by certain attributes.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/statuses/'/></para>
/// </summary>
public interface IStatuses
{
	/// <summary>
	/// Get Status of Work Package by ID
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Get("/statuses/{workPackageId}")]
	Task<Status> GetAsync(
		int workPackageId,
		CancellationToken cancellationToken);
}