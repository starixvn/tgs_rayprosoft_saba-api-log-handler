using System.ComponentModel.DataAnnotations;

namespace S1ApiLog.Common;
public record ApiLogMessage
{
	[Required]
	public string GameProviderCode { get; set; }

	[Key]
	public string Key { get; init; } = default!;

	[Required]
	public string Action { get; init; } = default!;

	public dynamic Request { get; init; } = default!;

	public dynamic Response { get; init; } = default!;
}