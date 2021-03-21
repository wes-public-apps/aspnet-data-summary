
using System.Collections.Generic;
using System.Threading.Tasks;
using DataReviewProject.Models;
using MongoDB.Driver;
using System.Linq;

namespace DataReviewProject.Services {
    //Add support for crud operations.
    public class FlightDataService{
        private IMongoCollection<FlightData> _flightData;
        
        public FlightDataService(IFlightDataDatabaseSettings settings){
            MongoClient dbClient = new MongoClient(settings.ConnectionString);
            var db = dbClient.GetDatabase(settings.Database);
            _flightData = db.GetCollection<FlightData>(settings.CollectionName);
        }

        public async Task<List<FlightData>> GetAsync()=> (await _flightData.FindAsync(fd => true)).ToList();
        public async Task<FlightData> GetAsync(string id)=> (await _flightData.FindAsync(fd => fd.Id==id)).FirstOrDefault();
        public async void CreateAsync(FlightData flightData)=> await _flightData.InsertOneAsync(flightData);
        public async void UpdateAsync(string id, FlightData flightDataIn) => await _flightData.ReplaceOneAsync(fd => fd.Id == id, flightDataIn);
        public async void RemoveAsync(string id) => await _flightData.DeleteOneAsync(fd => fd.Id == id);
        public async void RemoveAsync(FlightData flightData) => await _flightData.DeleteOneAsync(fd => fd.Id == flightData.Id);
        public  List<FlightData> Get()=> _flightData.Find(fd => true).ToList();
        public  FlightData Get(string id)=> _flightData.Find(fd => fd.Id==id).FirstOrDefault();
        public  void Create(FlightData flightData)=> _flightData.InsertOne(flightData);
        public  void Update(string id, FlightData flightDataIn) => _flightData.ReplaceOne(fd => fd.Id == id, flightDataIn);
        public  void Remove(string id) => _flightData.DeleteOne(fd => fd.Id == id);
        public  void Remove(FlightData flightData) => _flightData.DeleteOne(fd => fd.Id == flightData.Id);

    }
}