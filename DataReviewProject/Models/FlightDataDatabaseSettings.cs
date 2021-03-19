// Wesley Murray
// 3/19/2021
// Define database settings retreived from appsettings.json

namespace DataReviewProject.Models{
    public class FlightDataDatabaseSettings : IFlightDataDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IFlightDataDatabaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}