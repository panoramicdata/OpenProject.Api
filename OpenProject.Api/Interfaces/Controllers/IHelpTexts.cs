using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Attribute help texts provide additional information for attributes in work packages and projects
/// <para>See <a href='https://www.openproject.org/docs/system-admin-guide/attribute-help-texts/'/></para>
/// </summary>
public interface IHelpTexts
{
	/// <summary>
	/// Get All Help Texts
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/help_texts")]
	Task<OpenProjectItemSet<HelpText>> GetAllAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Get Help Text by ID
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/help_texts/{id}")]
	Task<HelpText> GetAsync(int id, CancellationToken cancellationToken);
}
