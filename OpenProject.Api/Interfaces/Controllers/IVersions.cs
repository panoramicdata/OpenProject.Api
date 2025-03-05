using OpenProject.Api.Data.Models;
using Version = OpenProject.Api.Data.Models.Version;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Work Packages can be assigned to a version. As such, versions serve to group Work Packages into logical units where each group comprises all the work packages that needs to be finished in order for the version to be finished.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/versions/'/></para>
/// </summary>
public interface IVersions
{
	/// <summary>
	/// Get all Versions
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/versions")]
	Task<OpenProjectItemSet<Version>> GetAllAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Get Version by Id
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/versions/{id}")]
	Task<Version> GetAsync(int id, CancellationToken cancellationToken);

	/// <summary>
	/// Gets a list of projects in which a version can be created in. The list contains all projects in which the user issuing the request has the manage versions permissions.
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/versions/available_projects")]
	Task<OpenProjectItemSet<Project>> GetAvailableProjectsAsync(CancellationToken cancellationToken);
}
