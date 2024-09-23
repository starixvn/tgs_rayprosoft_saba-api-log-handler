namespace SabaApiLog.Handler;

public record MongoDBOptions
{
    public string ConnectionString { get; set; } = "mongodb://localhost";
}