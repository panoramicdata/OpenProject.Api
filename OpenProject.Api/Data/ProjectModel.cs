namespace OpenProject.Api.Data;

public class ProjectModel : ItemModel
{
	public string identifier { get; set; }
	public string name { get; set; }
	public bool active { get; set; }
	public bool _public { get; set; }
	public Description description { get; set; }
	public StatusExplanation statusExplanation { get; set; }
}
