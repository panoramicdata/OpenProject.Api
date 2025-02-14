namespace OpenProject.Api.Data;

public class Formattable
{
	public required string Format { get; set; }

	public required string Raw { get; set; }

	public required string Html { get; set; }
}
