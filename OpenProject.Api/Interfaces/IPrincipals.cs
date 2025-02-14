namespace OpenProject.Api.Interfaces;

/// <summary>
/// Principals
/// See https://www.openproject.org/docs/api/endpoints/groups/
/// </summary>
public interface IPrincipals
{
	/// <summary>
	/// Get all principals
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroups</returns>
	[Get("/principals")]
	Task<OpenProjectItemSet<Principal>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get principal
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroup</returns>
	[Get("/principals/{id}")]
	Task<Principal> GetAsync(
		int id,
		CancellationToken cancellationToken);
}
