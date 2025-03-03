using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Users and groups can become Members of a project. Such a Membership will also have one or more roles assigned to it. By that, memberships control the permissions a user has within a project.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/memberships/'/></para>
/// </summary>
public interface IMemberships
{
	/// <summary>
	/// Get all Memberships
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroups</returns>
	[Get("/memberships")]
	Task<OpenProjectItemSet<Membership>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get Membership by ID
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroup</returns>
	[Get("/memberships/{id}")]
	Task<Membership> GetAsync(
		int id,
		CancellationToken cancellationToken);
}