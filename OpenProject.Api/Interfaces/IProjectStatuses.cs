namespace OpenProject.Api.Interfaces;

/// <summary>
/// Project Status endpoints
/// See https://www.openproject.org/docs/api/endpoints/projects/
/// </summary>
public interface IProjectStatuses
{
	/// <summary>
	/// Get project status
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Post("/project_statuses")]
	Task<ProjectStatusModel> GetAsync(
		string id,
		CancellationToken cancellationToken);
}
