using S1ApiLog.Core.Repositories;
using Tgs.ServiceUtility;

namespace S1ApiLog.Core.ApplicationServices;

public class ApiLogsCommandService(IApiLogsRepository logRepository) : ICommandService<ApiLogsCommand>
{
	public async ValueTask ExecuteAsync(ApiLogsCommand command, CancellationToken cancellationToken = default)
	{
		_ = await logRepository.AddAsync(command.GameProviderCode, command.Action, command.Req, command.Res, cancellationToken);
	}
}