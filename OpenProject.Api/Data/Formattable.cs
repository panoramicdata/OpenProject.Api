using OpenProject.Api.Enums;

namespace OpenProject.Api.Data;

/// <summary>
/// OpenProject supports text formatting in Markdown. Properties that contain formattable text have a special representation in this API. In this specification their type is indicated as Formattable.
/// <para>See <a href='https://www.openproject.org/docs/api/basic-objects/#formattable-text'/></para>
/// </summary>
public class Formattable
{
	/// <summary>
	/// Indicates the formatting language of the raw text
	/// </summary>
	public required Format Format { get; set; }

	/// <summary>
	/// The raw text, as entered by the user e.g."I **am** formatted!"
	/// </summary>
	public required string Raw { get; set; }

	/// <summary>
	/// The text converted to HTML according to the format	e.g. "I <strong>am</strong> formatted!"
	/// </summary>
	public required string Html { get; set; }
}
