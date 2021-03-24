using System.Collections.Generic;

namespace DataReviewProject.Utils.Types {
    public enum TimeUnits{
        Seconds,
        Minutes,
        Hours,
    }

    public enum TemperatureUnits {
        F,
        C,
        K,
    }

    public enum HardwareTypes {
        Sensor,
        SensorGroup,
    }

    public enum SensorTypes {
        Temperature,
        Position,
    }

    public interface Labeled {
        StatusTypes Status {get;set;}
        string Name {get;set;}
        string Description {get;set;}
    }

    public enum StatusTypes {
        Active,
        Inactive,
    }

    public static class TypeToDisplayString{
        public static Dictionary<HardwareTypes,string> HardwareTypeMap=new Dictionary<HardwareTypes, string>(){
            {HardwareTypes.Sensor,"Sensor"},
            {HardwareTypes.SensorGroup,"Sensor Group"},
        };
        public static Dictionary<StatusTypes,string> StatusTypeMap=new Dictionary<StatusTypes, string>(){
            {StatusTypes.Active,"Active"},
            {StatusTypes.Inactive,"Inactive"},
        };
        public static Dictionary<SensorTypes,string> SensorTypeMap=new Dictionary<SensorTypes, string>(){
            {SensorTypes.Temperature,"Temperature Sensor"},
            {SensorTypes.Position,"Position Sensor"},
        };
        public static Dictionary<TimeUnits,string> TimeUnitMap=new Dictionary<TimeUnits, string>(){
            {TimeUnits.Seconds,"s"},
            {TimeUnits.Minutes,"m"},
            {TimeUnits.Hours,"h"},
        };
    }
}