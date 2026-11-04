using OpenProject.Api.Data.Models.Create;

namespace OpenProject.Api.Test.Tests;

/// <summary>
/// <see cref="OpenProjectClientOptions.IsReadOnly"/> needs no configuration, network or server.
/// </summary>
public class ReadOnlyOptionTests
{
	private static bool IsRefused(Exception e)
		=> e is InvalidOperationException || e.InnerException is InvalidOperationException;

	private static OpenProjectClient ClientFor(bool isReadOnly)
		=> new(new OpenProjectClientOptions
		{
			Uri = new Uri("http://127.0.0.1:1"),
			ApiKey = "not-a-real-key",
			IsReadOnly = isReadOnly
		});

	[Fact]
	public void IsReadOnly_DefaultsToFalse()
		=> new OpenProjectClientOptions { Uri = new Uri("http://127.0.0.1:1"), ApiKey = "k" }
			.IsReadOnly.Should().BeFalse();

	[Fact]
	public async Task ReadOnly_Create_ThrowsInvalidOperationBeforeSending()
	{
		using var client = ClientFor(isReadOnly: true);

		var act = () => client.Projects.CreateAsync(new ProjectCreate { Name = "p" }, CancellationToken.None);

		var thrown = await act.Should().ThrowAsync<Exception>();
		IsRefused(thrown.Which).Should().BeTrue();
	}

	[Fact]
	public async Task NotReadOnly_Create_IsAttemptedAndFailsOnConnectionNotOnPolicy()
	{
		using var client = ClientFor(isReadOnly: false);

		var act = () => client.Projects.CreateAsync(new ProjectCreate { Name = "p" }, CancellationToken.None);

		var thrown = await act.Should().ThrowAsync<Exception>();
		IsRefused(thrown.Which).Should().BeFalse();
	}

	[Fact]
	public async Task ReadOnly_Get_IsNotRefused()
	{
		using var client = ClientFor(isReadOnly: true);

		var act = () => client.Projects.GetAllAsync(CancellationToken.None);

		var thrown = await act.Should().ThrowAsync<Exception>();
		IsRefused(thrown.Which).Should().BeFalse();
	}
}
