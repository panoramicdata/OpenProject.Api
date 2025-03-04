using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// A Document is a file containing a list of attachments
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/documents/'/></para>
/// </summary>
public interface IDocuments
{
	/// <summary>
	/// Get all Documents
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/documents")]
	Task<OpenProjectItemSet<Document>> GetAllAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Get a Document by ID
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/documents/{id}")]
	Task<Document> GetAsync(int id, CancellationToken cancellationToken);
}
