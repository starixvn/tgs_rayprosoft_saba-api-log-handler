namespace S1ApiLog.Core.Configuarations;
public record PolicySettingsOptions
{
	public int RetryCount { get; init; } = 3;
	public int RetrySeconds { get; init; } = 2;
}