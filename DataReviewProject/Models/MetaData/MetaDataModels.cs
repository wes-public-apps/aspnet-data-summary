
using System.Collections.Generic;
using DataReviewProject.Utils.Types;

namespace DataReviewProject.Models.MetaDataModels {
    public class HardwareMetaData {
        public string Id {get; set; }
        public StatusTypes Status {get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public HardwareMetaData(string id,StatusTypes status,string name,string description){
            this.Id = id;
            this.Status = status;
            this.Name = name;
            this.Description = description;
        }
    }

    public class SensorGroupMetaData: HardwareMetaData {
        public List<SensorMetaData> Sensors {get;set;}
        public SensorGroupMetaData(string id,StatusTypes status,string name,string description)
            :base(id,status,name,description){}
        public SensorGroupMetaData(string id,StatusTypes status,string name,string description,List<SensorMetaData> sensors)
            :base(id,status,name,description){
                this.Sensors = sensors;
            }
        public void addSensor(SensorMetaData sensor) => this.Sensors.Add(sensor);
    }

    public class SensorMetaData: HardwareMetaData
    {
        public SensorTypes Type {get;set;}
        public SensorMetaData(string id,StatusTypes status,string name,string description)
            :base(id,status,name,description){}
    }
}
