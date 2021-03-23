// Wesley Murray
// 3/22/2021
// Define classes to hold sensor related information 

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataReviewProject.Models.HardwareModels {
    public interface Sensor {
    }

    public class SensorGroup: Hardware, Sensor {
        private Sensor[] Sensors { get; set; }
    }

    public class NumericSensor: Hardware, Sensor {
        SensorData<double> RawData { get; set; } 

        public NumericSensor(MetaData metaData):base(metaData){
            this.RawData = null;
        }
    }
}