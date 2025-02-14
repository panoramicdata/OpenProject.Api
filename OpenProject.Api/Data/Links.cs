namespace OpenProject.Api.Data;

public class Links
{
	public required HrefAndMethod Self { get; set; }

	public HrefAndMethod? JumpTo { get; set; }

	public HrefAndMethod? ChangeSize { get; set; }

	public ICollection<Representation> Representations { get; set; } = [];
}
