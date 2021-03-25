// Wesley Murray
// 3/22/2021
// Define Sensor Data container classes.

using System.Collections.Generic;
using DataReviewProject.Models.DataFrameModels;
using DataReviewProject.Utils.Types;

namespace DataReviewProject.Models.SensorDataModels {
    public enum SensorTypes {
        Temperature,
        Position,
    }

    public static class SensorTypesToDisplayString{
        public static Dictionary<SensorTypes,string> Map=new Dictionary<SensorTypes, string>(){
            {SensorTypes.Temperature,"Temperature"},
            {SensorTypes.Position,"Position"},
        };
    }

    //Parent Sensor Data Class
    public class SensorData {
        public string IndependentVarLabel { get; set; }
        public string DependentVarLabel { get; set; }

        public SensorData(){
            this.IndependentVarLabel="Independent Variable";
            this.DependentVarLabel="Dependent Variable";
        }
        public SensorData(string indepVarLabel, string depVarLabel){
            this.IndependentVarLabel=indepVarLabel;
            this.DependentVarLabel=depVarLabel;
        }
    }

    //Class to hold temperature sensor data
    public class TemperatureSensorData: SensorData {
        private TimeUnits TimeUnit {get;set;}
        private TemperatureUnits TemperatureUnit {get;set;}
        private double CurrentPos {get;set;}
        private double Step {get;set;}
        public Dictionary<double,PeriodicNumericDataFrame<double>> Data { get; set; }

        public TemperatureSensorData(TimeUnits timeUnit,TemperatureUnits tempUnit,double startPos,double step)
            :base("Time(s)","Temperature(F)"){
            this.CurrentPos=startPos;
            this.Step=step;
        }
        public TemperatureSensorData(TimeUnits timeUnit,TemperatureUnits tempUnit,double startPos,double step,Dictionary<double,PeriodicNumericDataFrame<double>> data,string indepVarLabel, string depVarLabel)
            :base(indepVarLabel,depVarLabel){
            this.CurrentPos=startPos;
            this.Step=step;
            this.Data=data;
        }

        public void addData(PeriodicNumericDataFrame<double> dataFrame)=> this.Data.Add(CurrentPos+=Step,dataFrame);
        public void addData(double value, double err)=> this.Data.Add(CurrentPos+=Step,new PeriodicNumericDataFrame<double>(value,err));
    }
}