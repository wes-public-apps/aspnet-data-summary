// Wesley Murray
// 3/22/2021
// Create a struct to hold data frames.

namespace DataReviewProject.Models.DataFrameModels {
    // Basic data frame for a aperiodic sensor
    // Used generics to switch between different types as necessary.
    public class APeriodicDataFrame<X,Y> {
        public X IndependentVar { get; }
        public Y DependentVar { get; }
        public APeriodicDataFrame(X independentVar, Y dependentVar){
            this.IndependentVar = independentVar;
            this.DependentVar = dependentVar;
        }

        public override string ToString() => $"({this.IndependentVar},{this.DependentVar})";
    }

    // Basic data frame for a periodic sensor
    // Used generics to switch between different types as necessary.
    public class PeriodicDataFrame<T> {
        public T DependentVar { get; }
        public PeriodicDataFrame(T dependentVar){
            this.DependentVar = dependentVar;
        }

        public override string ToString() => $"{this.DependentVar}";
    }

    // Basic data frame for a periodic numeric sensor
    // Used generics to switch between different number types as necessary.
    public class APeriodicNumericDataFrame<X,Y>:APeriodicDataFrame<X,Y> {
        public Y Err { get; }

        public APeriodicNumericDataFrame(X indepVar, Y depVar, Y err):base(indepVar,depVar){
            this.Err = err;
        }

        public override string ToString() => $"({this.IndependentVar},{this.DependentVar}+/-{this.Err}";
    }

    // Basic data frame for a periodic numeric sensor
    // Used generics to switch between different number types as necessary.
    public class PeriodicNumericDataFrame<T>:PeriodicDataFrame<T> {
        public T Err { get; }

        public PeriodicNumericDataFrame(T depVar, T err):base(depVar){
            this.Err = err;
        }

        public override string ToString() => $"{this.DependentVar}+/-{this.Err}";
    }
}