
using System.Collections.Generic;
using DataReviewProject.Models.SensorDataModels;
using DataReviewProject.Utils.Types;

namespace DataReviewProject.Models.MetaDataModels {

    public enum HardwareTypes {
        Sensor,
        SensorGroup,
    }

    public static class HardwareTypesToDisplayString{
        public static Dictionary<HardwareTypes,string> Map=new Dictionary<HardwareTypes, string>(){
            {HardwareTypes.Sensor,"Sensor"},
            {HardwareTypes.SensorGroup,"Sensor Group"},
        };
    }

    public class HardwareMetaData {
        public string Id {get; set; }
        public StatusTypes Status {get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public HardwareMetaData(){}
        public HardwareMetaData(string id,StatusTypes status,string name,string description){
            this.Id = id;
            this.Status = status;
            this.Name = name;
            this.Description = description;
        }
    }

    public class SensorGroupMetaData: HardwareMetaData {
        public List<HardwareMetaData> Sensors {get;set;}
        public SensorGroupMetaData(){}
        public SensorGroupMetaData(string id,StatusTypes status,string name,string description)
            :base(id,status,name,description){}
        public SensorGroupMetaData(string id,StatusTypes status,string name,string description,List<HardwareMetaData> sensors)
            :base(id,status,name,description){
                this.Sensors = sensors;
            }
        public void addSensor(SensorMetaData sensor) => this.Sensors.Add(sensor);
    }

    public class SensorMetaData: HardwareMetaData
    {
        public SensorTypes Type {get;set;}
        public SensorMetaData(){}
        public SensorMetaData(string id,StatusTypes status,string name,string description)
            :base(id,status,name,description){}
    }
}
