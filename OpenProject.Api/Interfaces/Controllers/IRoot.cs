namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// The root resource contains links to available resources in the API. By following these links a client should be able to discover further resources in the API.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/root/'/></para>
/// </summary>
public interface IRoot
{
	/// <summary>
	/// Get information about the OpenProject instance
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/")]
	Task<ApiInformation> GetApiInformationAsync(CancellationToken cancellationToken);
}
