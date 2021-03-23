// Wesley Murray
// 3/22/2021
// Define classes to hold hardware related information

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataReviewProject.Models.HardwareModels {
    public static class HardwareTypes {
        public const string NumericSensor = "NumericSensor";
    }

    public struct MetaData
    {
        public string Name {get;set;}
        public string Description {get;set;}
        public MetaData(string name, string description){
            this.Name=name;
            this.Description=description;
        }
    }

    public class Hardware {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public MetaData MetaData {get; set;}

        public Hardware(){}
        public Hardware(MetaData metaData){
            this.Id = ObjectId.GenerateNewId();
            this.MetaData=metaData;
        }
    }
}