namespace OpenProject.Api.Queries;

public class OperatorValues
{
	public required FilterOperator Operator { get; set; }
	public required List<string> Values { get; set; }
}
