using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace OpenProject.Api.Test;

[CollectionDefinition("Dependency Injection")]
public class TestBase : TestBed<Fixture>
{
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
}
