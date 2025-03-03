using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Categories are used to differentiate Work Packages, filter, and group by certain attributes.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/categories/'/></para>
/// </summary>
public interface ICategories
{
	/// <summary>
	/// Get Categories for a Project
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Returns a Task containing a collection of <see cref="Category"/></returns>
	[Get("/categories/{projectId}")]
	Task<OpenProjectItemSet<Category>> GetForProjectAsync(
		int projectId,
		CancellationToken cancellationToken);
}
