namespace OpenProject.Api.Data.Models;

public class WorkPackage : IdentifiedItem<int>, IHasTimestamps
{
	public string? DerivedStartDate { get; set; }

	public string? DerivedDueDate { get; set; }

	public string? StartDate { get; set; }

	public string? DueDate { get; set; }

	public string? Duration { get; set; }

	public string? SpentTime { get; set; }

	public string? LaborCosts { get; set; }

	public string? MaterialCosts { get; set; }

	public string? OverallCosts { get; set; }

	public required int LockVersion { get; set; }

	public required string Subject { get; set; }

	public required Formattable Description { get; set; }

	public required bool ScheduleManually { get; set; }

	public required object EstimatedTime { get; set; }

	public required object DerivedEstimatedTime { get; set; }

	public required object DerivedRemainingTime { get; set; }

	public required bool IgnoreNonWorkingDays { get; set; }

	public required int? PercentageDone { get; set; }

	public required int? DerivedPercentageDone { get; set; }

	public DateTime CreatedAt { get; set; }

	public DateTime UpdatedAt { get; set; }
}