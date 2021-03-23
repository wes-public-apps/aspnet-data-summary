// Wesley Murray
// 3/22/2021
// Define Sensor Data container classes.

using System.Collections.Generic;

namespace DataReviewProject.Models {
    //Parent Sensor Data Class
    public class SensorData<T> {

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

        public virtual Dictionary<double,T> getData() => null;
    }

    //Sensor data that is periodic in nature
    public class PeriodicSensorData<T>: SensorData<T> {
        private double Start { get; set; }
        private double Step { get; set; }
        private T[] Data { get; set; }

        public PeriodicSensorData(double start, double step,T[] data,string indepVarLabel, string depVarLabel):base(indepVarLabel,depVarLabel){
            this.Start = start;
            this.Step = step;
            this.Data = data;
        }

        public override Dictionary<double,T> getData(){
            Dictionary<double,T> temp = new Dictionary<double,T>();
            double index = this.Start;
            foreach (T item in this.Data)
            {
                temp.Add(index,item);
                index+=this.Step;
            }
            return temp;
        }
    }

    //Sensor data that is not periodic in nature
    public class AperiodicSensorData<T>: SensorData<T> {
        private Dictionary<double,T> Data { get; set; }

        public AperiodicSensorData(Dictionary<double,T> data,string indepVarLabel, string depVarLabel):base(indepVarLabel,depVarLabel){
            this.Data = data;
        }

        public override Dictionary<double,T> getData(){
            return this.Data;
        }
    }
}