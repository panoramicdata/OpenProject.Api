using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// A View is a representation of some information. That information might be a query (currently it always is). The view will store the configuration on how to display the information but not the information itself.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/views/'/></para>
/// </summary>
public interface IViews
{
	/// <summary>
	/// Get all Views
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/views")]
	Task<OpenProjectItemSet<View>> GetAllAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Get a View by ID
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/views/{id}")]
	Task<View> GetAsync(int id, CancellationToken cancellationToken);
}
