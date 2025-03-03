using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Principals are the superclass of users, groups and placeholder users. This end point returns all principals within a joined collection but can be filtered to e.g. only return groups or users.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/groups/'/></para>
/// </summary>
public interface IPrincipals
{
	/// <summary>
	/// Get all Principals
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroups</returns>
	[Get("/principals")]
	Task<OpenProjectItemSet<Principal>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get Principal by ID
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroup</returns>
	[Get("/principals/{id}")]
	Task<Principal> GetAsync(
		int id,
		CancellationToken cancellationToken);
}
