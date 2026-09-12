using Refit;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace OpenProject.Api.Test;

[Collection("Dependency Injection")]
public class TestBase : TestBed<Fixture>
{
	protected static System.Threading.CancellationToken CancellationToken => TestContext.Current.CancellationToken;

	public OpenProjectClient OpenProjectClient { get; }
	public ILogger Log { get; }

	public TestBase(
		ITestOutputHelper testOutputHelper,
		Fixture fixture) : base(testOutputHelper, fixture)
	{
		ArgumentNullException.ThrowIfNull(testOutputHelper);
		ArgumentNullException.ThrowIfNull(fixture);

		// Logger
		var loggerFactory = fixture
			.GetService<ILoggerFactory>(testOutputHelper)
			?? throw new InvalidOperationException("LoggerFactory is null");
		Log = loggerFactory.CreateLogger(GetType());

		var options = fixture.GetService<IOptions<AppSettings>>(testOutputHelper)
			?? throw new InvalidOperationException("Missing options");
		var optionsValue = options.Value;

		OpenProjectClient = new OpenProjectClient(new OpenProjectClientOptions
		{
			Uri = new(optionsValue.Url),
			ApiKey = optionsValue.ApiKey,
			Logger = Log,
		});
	}

	/// <summary>
	/// Fetches a collection and asserts that the response and its embedded payload are present.
	/// </summary>
	protected static async Task<Embedded<TElement>> AssertGetAllAsync<TElement>(
		Func<CancellationToken, Task<OpenProjectItemSet<TElement>>> getAllAsync)
		where TElement : ItemBase
	{
		var items = await getAllAsync(CancellationToken);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		return items.Embedded;
	}

	/// <summary>
	/// Fetches a collection and asserts that the response, its embedded payload and its
	/// elements are all present, returning the elements.
	/// </summary>
	protected static async Task<IReadOnlyCollection<TElement>> AssertGetAllElementsAsync<TElement>(
		Func<CancellationToken, Task<OpenProjectItemSet<TElement>>> getAllAsync)
		where TElement : ItemBase
	{
		var embedded = await AssertGetAllAsync(getAllAsync);

		embedded.Elements.Should().NotBeNull();

		return embedded.Elements;
	}

	/// <summary>
	/// Fetches a collection, then re-fetches every element by its identifier and asserts that
	/// each response is present. This is the "list, then get each" shape shared by most endpoints.
	/// </summary>
	protected static async Task AssertGetAllThenGetEachAsync<TElement, TResult>(
		Func<CancellationToken, Task<OpenProjectItemSet<TElement>>> getAllAsync,
		Func<TElement, CancellationToken, Task<TResult>> getAsync)
		where TElement : ItemBase
	{
		foreach (var element in await AssertGetAllElementsAsync(getAllAsync))
		{
			var refetched = await getAsync(element, CancellationToken);

			refetched.Should().NotBeNull();
		}
	}

	/// <summary>
	/// Creates a resource, asserts that the create response is present, then deletes it and
	/// returns the delete response so the caller can assert on it. This is the "create, then
	/// delete" shape shared by the endpoints that support both, and it leaves nothing behind
	/// when the assertions pass.
	/// </summary>
	protected static Task<TDeleteResponse> AssertCreateThenDeleteAsync<TCreated, TDeleteResponse>(
		Func<CancellationToken, Task<TCreated>> createAsync,
		Func<TCreated, CancellationToken, Task<TDeleteResponse>> deleteAsync)
		=> CreateThenDeleteCoreAsync(createAsync, deleteAsync, null);

	/// <summary>
	/// Creates a resource, asserts that the create response is present and satisfies
	/// <paramref name="assertCreated"/>, then deletes it and returns the delete response so the
	/// caller can assert on it.
	/// </summary>
	protected static Task<TDeleteResponse> AssertCreateThenDeleteAsync<TCreated, TDeleteResponse>(
		Func<CancellationToken, Task<TCreated>> createAsync,
		Func<TCreated, CancellationToken, Task<TDeleteResponse>> deleteAsync,
		Action<TCreated> assertCreated)
		=> CreateThenDeleteCoreAsync(createAsync, deleteAsync, assertCreated);

	/// <summary>
	/// Asserts that a delete response is present and reported success.
	/// </summary>
	protected static void AssertDeleteSucceeded(IApiResponse deleteResponse)
	{
		deleteResponse.Should().NotBeNull();
		deleteResponse.IsSuccessStatusCode.Should().BeTrue();
	}

	private static async Task<TDeleteResponse> CreateThenDeleteCoreAsync<TCreated, TDeleteResponse>(
		Func<CancellationToken, Task<TCreated>> createAsync,
		Func<TCreated, CancellationToken, Task<TDeleteResponse>> deleteAsync,
		Action<TCreated>? assertCreated)
	{
		var created = await createAsync(CancellationToken);

		created.Should().NotBeNull();
		assertCreated?.Invoke(created);

		return await deleteAsync(created, CancellationToken);
	}
}
