using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Represents a relation between two work packages.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/relations/'/></para>
/// </summary>
public interface IRelations
{
	/// <summary>
	/// Get all Relations
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/relations")]
	Task<OpenProjectItemSet<Relation>> GetAllAsync(
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Get Relation by ID
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/relations/{id}")]
	Task<Relation> GetAsync(
		int id,
		CancellationToken cancellationToken = default);
}
