using System.Collections.Generic;
using DataReviewProject.Models.MetaDataModels;
using DataReviewProject.Utils.Types;

namespace DataReviewProject.Utils.Factories{
    public static class HardwareMetaDataFactory {
        public static HardwareMetaData GetMetaData(HardwareTypes type,string id,StatusTypes status,string name,string description,List<HardwareMetaData> sensors){
            switch(type){
                case HardwareTypes.Sensor:
                    return new SensorMetaData(id,status,name,description);
                case HardwareTypes.SensorGroup:
                    return new SensorGroupMetaData(id,status,name,description,sensors);
                default:
                    return null;
            }
        }
    }
}