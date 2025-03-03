using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Work Package Category
/// See https://www.openproject.org/docs/api/endpoints/categories/
/// </summary>
public interface IWorkPackageCategories
{
	/// <summary>
	/// Get Categories for a Project
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Returns a Task containing a collection of <see cref="WorkPackageCategory"/></returns>
	[Get("/categories/{projectId}")]
	Task<OpenProjectItemSet<WorkPackageCategory>> GetForProjectAsync(
		int projectId,
		CancellationToken cancellationToken);
}
