// Wesley Murray
// 3/19/2021
// This model tracks flight data.

using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using DataReviewProject.Models.SensorDataModels;

namespace DataReviewProject.Models.Data {
    public class FlightData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime TimeStamp { get; set; }

        public List<SensorData> Data { get; set; }

        public FlightData(){
            this.TimeStamp = DateTime.Now;
            this.Id=ObjectId.GenerateNewId().ToString();
        }

        public FlightData(List<SensorData> data){
            this.TimeStamp = DateTime.Now;
            this.Id=ObjectId.GenerateNewId().ToString();
            this.Data=data;
        }

    }
}