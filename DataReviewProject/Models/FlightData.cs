// Wesley Murray
// 3/19/2021
// This model tracks flight data.

using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataReviewProject.Models {
    public class FlightData{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime TimeStamp { get; set; }

        public FlightData(){
            this.TimeStamp = DateTime.Now;
            this.Id=ObjectId.GenerateNewId();
        }

        public FlightData(string name){
            this.Name=name;
            this.TimeStamp = DateTime.Now;
            this.Id=ObjectId.GenerateNewId();
        }

    }
}