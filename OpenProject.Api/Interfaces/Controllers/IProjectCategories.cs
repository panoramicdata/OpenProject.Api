using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Project Category endpoints
/// See https://www.openproject.org/docs/api/endpoints/categories/
/// </summary>
public interface IProjectCategories
{
	/// <summary>
	/// Get project status
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Get("/categories/{projectId}")]
	Task<OpenProjectItemSet<ProjectCategory>> GetForProjectAsync(
		int projectId,
		CancellationToken cancellationToken);
}
