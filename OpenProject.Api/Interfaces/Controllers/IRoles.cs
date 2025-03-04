using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Roles regulate access to specific resources by having permissions configured for them.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/roles/'/></para>
/// </summary>
public interface IRoles
{
	/// <summary>
	/// Get all Roles
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/roles")]
	Task<OpenProjectItemSet<Role>> GetAllAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Get Role by ID
	/// </summary>
	/// <param name="roleId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/roles/{roleId}")]
	Task<Role> GetAsync(int roleId, CancellationToken cancellationToken);
}
