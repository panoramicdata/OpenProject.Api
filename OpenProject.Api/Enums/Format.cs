namespace OpenProject.Api.Enums;

/// <summary>
/// Indicates the formatting language of the raw text
/// <para>See <a href='https://www.openproject.org/docs/api/basic-objects/#formattable-text'/></para>
/// </summary>
public enum Format
{
	/// <summary>
	/// Only basic formatting, e.g. inserting paragraphs and line breaks into HTML
	/// </summary>
	Plain,

	/// <summary>
	/// Formatting using Markdown
	/// </summary>
	Markdown,

	/// <summary>
	/// There is no apparent formatting rule that transforms the raw version to HTML (only used for read only properties)
	/// </summary>
	Custom
}
