using OpenProject.Api.Data.Models.Create;
using OpenProject.Api.Data.Models.Update;

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

	private static async Task<bool> WasRefusedAsync<T>(bool isReadOnly, Func<OpenProjectClient, Task<T>> call)
	{
		using var client = ClientFor(isReadOnly);

		var thrown = await FluentActions.Awaiting(() => call(client)).Should().ThrowAsync<Exception>();
		return IsRefused(thrown.Which);
	}

	[Fact]
	public async Task ReadOnly_Create_ThrowsInvalidOperationBeforeSending()
		=> (await WasRefusedAsync(true, c => c.Projects.CreateAsync(new ProjectCreate { Name = "p" }, CancellationToken.None)))
			.Should().BeTrue();

	[Fact]
	public async Task ReadOnly_WorkPackageUpdate_ThrowsInvalidOperationBeforeSending()
		=> (await WasRefusedAsync(true, c => c.WorkPackages.UpdateAsync(1, new WorkPackageUpdate { LockVersion = 1 }, CancellationToken.None)))
			.Should().BeTrue();

	[Fact]
	public async Task NotReadOnly_Create_IsAttemptedAndFailsOnConnectionNotOnPolicy()
		=> (await WasRefusedAsync(false, c => c.Projects.CreateAsync(new ProjectCreate { Name = "p" }, CancellationToken.None)))
			.Should().BeFalse();

	[Fact]
	public async Task ReadOnly_Get_IsNotRefused()
		=> (await WasRefusedAsync(true, c => c.Projects.GetAllAsync(CancellationToken.None)))
			.Should().BeFalse();
}
