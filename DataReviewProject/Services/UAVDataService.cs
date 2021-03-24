
using System.Collections.Generic;
using System.Threading.Tasks;
using DataReviewProject.Models;
using MongoDB.Driver;
using System.Linq;
using MongoDB.Bson;
using DataReviewProject.Models.Data;
using DataReviewProject.Models.MetaDataModels;

namespace DataReviewProject.Services {
    //Add support for crud operations.
    public class UAVDataService{
        //List of collections contained in FlightData MongoDB
        private struct DatabaseCollections {
            public static string RawFlightData = "RawFlightData";
            public static string HardwareList = "HardwareList";
            public static string UAVList = "UAVList";
        }
        private IMongoCollection<FlightData> _flightData;
        private IMongoCollection<HardwareMetaData> _hardwareList;
        private IMongoCollection<UAV> _UAVList;
        
        public UAVDataService(MongoDBSettings settings){
            MongoClient dbClient = new MongoClient(settings.ConnectionString);
            var db = dbClient.GetDatabase(settings.Database);
            _flightData = db.GetCollection<FlightData>(UAVDataService.DatabaseCollections.RawFlightData);
            _hardwareList = db.GetCollection<HardwareMetaData>(UAVDataService.DatabaseCollections.HardwareList);
            _UAVList = db.GetCollection<UAV>(UAVDataService.DatabaseCollections.UAVList);
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
        public async Task<List<HardwareMetaData>> GetHardwareAsync()=> (await _hardwareList.FindAsync(hardware => true)).ToList();
        public async Task<HardwareMetaData> GetHardwareAsync(string id)=> (await _hardwareList.FindAsync(hardware => hardware.Id==id)).FirstOrDefault();
        public async Task CreateHardwareAsync(HardwareMetaData hardware)=> await _hardwareList.InsertOneAsync(hardware);
        public async Task UpdateHardwareAsync(string id, HardwareMetaData hardwareIn) => await _hardwareList.ReplaceOneAsync(hardware => hardware.Id == id, hardwareIn);
        public async Task RemoveHardwareAsync(string id) => await _hardwareList.DeleteOneAsync(hardware => hardware.Id == id);
        public async Task RemoveHardwareAsync(HardwareMetaData uav) => await _UAVList.DeleteOneAsync(uav => uav.Id == uav.Id);
        #endregion

        #region UAVs
        public async Task<List<UAV>> GetUavAsync()=> (await _UAVList.FindAsync(uav => true)).ToList();
        public async Task<UAV> GetUavAsync(string id)=> (await _UAVList.FindAsync(uav => uav.Id==id)).FirstOrDefault();
        public async Task CreateUavAsync(UAV uav)=> await _UAVList.InsertOneAsync(uav);
        public async Task UpdateUavAsync(string id, UAV uavIn) => await _UAVList.ReplaceOneAsync(uav => uav.Id == id, uavIn);
        public async Task RemoveUavAsync(string id) => await _UAVList.DeleteOneAsync(uav => uav.Id == id);
        public async Task RemoveUavAsync(UAV uav) => await _UAVList.DeleteOneAsync(uav => uav.Id == uav.Id);
        #endregion
        #endregion

    }
}