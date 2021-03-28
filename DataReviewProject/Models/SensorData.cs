// Wesley Murray
// 3/22/2021
// Define Sensor Data container classes.

using System.Collections.Generic;
using System.Linq;
using DataReviewProject.Models.DataFrameModels;
using DataReviewProject.Utils.Types;

namespace DataReviewProject.Models.SensorDataModels {
    #region Types
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
    #endregion

    #region SensorData Classes
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
        public virtual Chart GetDataPlot(){
            return null;
        }
    }

    //Class to hold temperature sensor data
    public class TemperatureSensorData: SensorData {
        private TimeUnits TimeUnit {get;set;}
        private TemperatureUnits TemperatureUnit {get;set;}
        private double StartPos {get;set;}
        private double Step {get;set;}
        public List<PeriodicNumericDataFrame<double>> Data { get; set; }

        public TemperatureSensorData(TimeUnits timeUnit,TemperatureUnits tempUnit,double startPos,double step)
            :base("Time(s)","Temperature(f)"){
            this.StartPos=startPos;
            this.Step=step;
            this.Data = new List<PeriodicNumericDataFrame<double>>();
        }
        public TemperatureSensorData(TimeUnits timeUnit,TemperatureUnits tempUnit,double startPos,double step,List<PeriodicNumericDataFrame<double>> data)
            :base("Time(s)","Temperature(f)"){
            this.StartPos=startPos;
            this.Step=step;
            this.Data=data;
        }

        public void addData(PeriodicNumericDataFrame<double> dataFrame)=> this.Data.Add(dataFrame);
        public void addData(double value, double err)=> this.Data.Add(new PeriodicNumericDataFrame<double>(value,err));

        public override Chart GetDataPlot(){
            double[] xValues=new double[this.Data.Count];
            double[] yValues=new double[this.Data.Count];
            xValues[0]=this.StartPos;
            yValues[0]=this.Data.First().DependentVar;
            for(int i=1;i<this.Data.Count;i++) {
                xValues[i]=xValues[i-1]+this.Step;
                yValues[i]=this.Data[i].DependentVar;
            }
            return new Chart(1000,600)
                .AddTitle("Temperature")
                .AddSeries("Default",chartType: "Line",
                    xValue: xValues,
                    yValues: yValues
                ).Write();
        }
    }

    //Class to hold position data
    public class PositionSensorData: SensorData{
        private double StartPos {get;set;}
        private double Step {get;set;}
        public List<CartesianPositionDataFrame> Data {get;set;}
        public PositionSensorData(double startPos,double step):base("Time(s)","Position"){
            this.StartPos=startPos;
            this.Step=step;
            this.Data = new List<CartesianPositionDataFrame>();
        }
        public PositionSensorData(double startPos,double step,List<CartesianPositionDataFrame> data)
            :base("Time(s)","Position"){
            this.StartPos=startPos;
            this.Step=step;
            this.Data = data;
        }

        public override Chart GetDataPlot(){
            double[] xValues=new double[this.Data.Count];
            double[] yValues=new double[this.Data.Count];
            for(int i=0;i<this.Data.Count;i++) {
                xValues[i]=this.Data[i].X;
                yValues[i]=this.Data[i].Y;
            }
            return new Chart(1000,600)
                .AddTitle("Position")
                .AddSeries("Default",chartType: "Line",
                    xValue: xValues,
                    yValues: yValues
                ).Write();
        }
    }
    #endregion
}