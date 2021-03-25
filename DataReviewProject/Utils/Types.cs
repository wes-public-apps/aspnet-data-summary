using System.Collections.Generic;

namespace DataReviewProject.Utils.Types {
    #region Enums
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

    public enum StatusTypes {
        Active,
        Inactive,
    }
    #endregion

    #region Interfaces
    public interface Labeled {
        StatusTypes Status {get;set;}
        string Name {get;set;}
        string Description {get;set;}
    }
    #endregion

    #region Map Types to Display Strings
    public static class TypeToDisplayString{
        public static Dictionary<StatusTypes,string> StatusTypeMap=new Dictionary<StatusTypes, string>(){
            {StatusTypes.Active,"Active"},
            {StatusTypes.Inactive,"Inactive"},
        };
        public static Dictionary<TimeUnits,string> TimeUnitMap=new Dictionary<TimeUnits, string>(){
            {TimeUnits.Seconds,"s"},
            {TimeUnits.Minutes,"m"},
            {TimeUnits.Hours,"h"},
        };
    }
    #endregion
}