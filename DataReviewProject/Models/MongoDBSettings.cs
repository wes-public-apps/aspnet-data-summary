// Wesley Murray
// 3/19/2021
// Define database settings retreived from appsettings.json

namespace DataReviewProject.Models{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string Database { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConnectionString {
            get {
                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                    return $@"mongodb://{Host}:{Port}";
                return $@"mongodb://{Username}:{Password}@{Host}:{Port}";
            }
        }
    }

    public interface IMongoDBSettings
    {
        string Database { get; set; }
        string Host { get; set; }
        string Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string ConnectionString { get; }
    }
}