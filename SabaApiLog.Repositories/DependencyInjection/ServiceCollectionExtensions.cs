using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using SabaApiLog.Core.Repositories;

namespace SabaApiLog.Repositories.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddApiLogsRepositories(
		this IServiceCollection services,
		Func<IServiceProvider, IMongoClient> mongoClientResolver)
		=> services
		.AddTransient<IApiLogsRepository>((sp) => ActivatorUtilities.CreateInstance<ApiLogsRepository>(sp, mongoClientResolver(sp)));
}