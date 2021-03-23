
using System.Collections.Generic;
using System.Threading.Tasks;
using DataReviewProject.Models;
using DataReviewProject.Models.HardwareModels;
using MongoDB.Driver;
using System.Linq;
using MongoDB.Bson;

namespace DataReviewProject.Services {
    //Add support for crud operations.
    public class UAVDataService{
        //List of collections contained in FlightData MongoDB
        private struct DatabaseCollections {
            public static string RawFlightData = "RawFlightData";
            public static string HardwareList = "HardwareList";
        }
        private IMongoCollection<FlightData> _flightData;
        private IMongoCollection<Hardware> _hardwareList;
        
        public UAVDataService(MongoDBSettings settings){
            MongoClient dbClient = new MongoClient(settings.ConnectionString);
            var db = dbClient.GetDatabase(settings.Database);
            _flightData = db.GetCollection<FlightData>(UAVDataService.DatabaseCollections.RawFlightData);
            _hardwareList = db.GetCollection<Hardware>(UAVDataService.DatabaseCollections.HardwareList);
        }

        #region Async Data Management
        #region UAV FlightData
        public async Task<List<FlightData>> GetFlightDataAsync()=> (await _flightData.FindAsync(fd => true)).ToList();
        public async Task<FlightData> GetFlightDataAsync(ObjectId id)=> (await _flightData.FindAsync(fd => fd.Id==id)).FirstOrDefault();
        public async Task CreateFlightDataAsync(FlightData flightData)=> await _flightData.InsertOneAsync(flightData);
        public async Task UpdateFlightDataAsync(ObjectId id, FlightData flightDataIn) => await _flightData.ReplaceOneAsync(fd => fd.Id == id, flightDataIn);
        public async Task RemoveFlightDataAsync(ObjectId id) => await _flightData.DeleteOneAsync(fd => fd.Id == id);
        public async Task RemoveFlightDataAsync(FlightData flightData) => await _flightData.DeleteOneAsync(fd => fd.Id == flightData.Id);
        #endregion

        #region UAV Hardware
        public async Task<List<Hardware>> GetHardwareAsync()=> (await _hardwareList.FindAsync(hardware => true)).ToList();
        public async Task<Hardware> GetHardwareAsync(ObjectId id)=> (await _hardwareList.FindAsync(hardware => hardware.Id==id)).FirstOrDefault();
        public async Task CreateHardwareAsync(Hardware hardware)=> await _hardwareList.InsertOneAsync(hardware);
        public async Task UpdateHardwareAsync(ObjectId id, Hardware hardwareIn) => await _hardwareList.ReplaceOneAsync(hardware => hardware.Id == id, hardwareIn);
        public async Task RemoveHardwareAsync(ObjectId id) => await _hardwareList.DeleteOneAsync(hardware => hardware.Id == id);
        public async Task RemoveHardwareAsync(Hardware hardware) => await _hardwareList.DeleteOneAsync(hardware => hardware.Id == hardware.Id);
        #endregion
        #endregion

    }
}