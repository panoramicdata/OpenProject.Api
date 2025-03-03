using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Project Status endpoints
/// See https://www.openproject.org/docs/api/endpoints/projects/
/// </summary>
public interface IStatuses
{
	/// <summary>
	/// Get project status
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Get("/project_statuses/{projectId}")]
	Task<Status> GetAsync(
		string projectId,
		CancellationToken cancellationToken);
}