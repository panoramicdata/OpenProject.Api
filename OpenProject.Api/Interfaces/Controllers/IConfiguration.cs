using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// The configuration endpoint allows to read certain configuration parameters of the OpenProject instance
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/configuration/' /></para>
/// </summary>
public interface IConfiguration
{
	/// <summary>
	/// Get the configuration of the OpenProject instance
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/configuration")]
	Task<Configuration> GetAsync(CancellationToken cancellationToken);
}
