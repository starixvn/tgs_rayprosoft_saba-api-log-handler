namespace S1ApiLog.Core.ApplicationServices;

public record ApiLogsCommand(string GameProviderCode, string Key, string Action, string Req, string Res);