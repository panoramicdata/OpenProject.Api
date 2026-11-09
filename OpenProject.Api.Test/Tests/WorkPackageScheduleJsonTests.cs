using OpenProject.Api.Data.Models;
using OpenProject.Api.Data.Models.Update;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace OpenProject.Api.Test.Tests;

/// <summary>
/// Work-package schedule fields are grouped in <see cref="WorkPackageSchedule"/> but stay flat in OpenProject's JSON.
/// </summary>
public class WorkPackageScheduleJsonTests
{
	private static readonly JsonSerializerOptions Options = OpenProjectClient.CreateJsonOptions();

	[Fact]
	public void WorkPackage_ReadsFlatScheduleFieldsIntoSchedule()
	{
		var workPackage = JsonSerializer.Deserialize<WorkPackage>(
			"""
			{"_type":"WorkPackage","_links":{},"id":7,"subject":"Ship it","percentageDone":10,"derivedPercentageDone":20,
			"scheduleManually":true,"startDate":"2026-11-02T00:00:00","dueDate":"2026-11-06T00:00:00",
			"date":null,"estimatedTime":"PT8H","derivedEstimatedTime":"PT16H"}
			""",
			Options)!;

		workPackage.Id.Should().Be(7);
		workPackage.Subject.Should().Be("Ship it");
		workPackage.Schedule.ScheduleManually.Should().BeTrue();
		workPackage.Schedule.StartDate.Should().Be(new DateTime(2026, 11, 2));
		workPackage.Schedule.DueDate.Should().Be(new DateTime(2026, 11, 6));
		workPackage.Schedule.Date.Should().BeNull();
		workPackage.Schedule.EstimatedTime.Should().Be("PT8H");
		workPackage.Schedule.DerivedEstimatedTime.Should().Be("PT16H");
	}

	[Fact]
	public void WorkPackageUpdate_WritesScheduleFieldsFlatAndLeavesNullsOut()
	{
		var update = new WorkPackageUpdate
		{
			LockVersion = 3,
			Schedule = new WorkPackageSchedule { StartDate = new DateTime(2026, 11, 2), EstimatedTime = "PT4H" }
		};

		var json = JsonNode.Parse(JsonSerializer.Serialize(update, Options))!.AsObject();

		json.Select(property => property.Key).Should().BeEquivalentTo("lockVersion", "startDate", "estimatedTime");
		json["lockVersion"]!.GetValue<int>().Should().Be(3);
		json["startDate"]!.GetValue<string>().Should().Be("2026-11-02T00:00:00");
		json["estimatedTime"]!.GetValue<string>().Should().Be("PT4H");
	}

	[Fact]
	public void WorkPackagesInACollection_AreReadThroughTheSameConverter()
	{
		var workPackages = JsonSerializer.Deserialize<List<WorkPackage>>(
			"""[{"_type":"WorkPackage","_links":{},"id":1,"subject":"a","percentageDone":0,"derivedPercentageDone":0,"dueDate":"2026-12-24T00:00:00"}]""",
			Options)!;

		workPackages.Should().ContainSingle().Which.Schedule.DueDate.Should().Be(new DateTime(2026, 12, 24));
	}
}
