namespace OpenProject.Api.Data;

public class Links
{
	public Self1 self { get; set; }
	public JumpTo jumpTo { get; set; }
	public ChangeSize changeSize { get; set; }
	public Representation[] representations { get; set; }
}
