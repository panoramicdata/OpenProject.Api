using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;

/// <summary>
/// Attribute help texts provide additional information for attributes in work packages and projects
/// <para>See <a href='https://www.openproject.org/docs/system-admin-guide/attribute-help-texts/'/></para>
/// </summary>
public class HelpText : IdentifiedItem<int>
{
	/// <summary>
	/// Attribute name	
	/// </summary>
	public required string Attribute { get; set; }

	/// <summary>
	/// Attribute caption	
	/// </summary>
	public string AttributeCaption { get; set; } = string.Empty;

	/// <summary>
	/// Help text content	
	/// </summary>
	[JsonPropertyName("helpText")]
	public required Formattable HelpTextContent { get; set; }
}
