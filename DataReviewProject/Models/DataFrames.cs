// Wesley Murray
// 3/22/2021
// Create a struct to hold data frames.

namespace DataReviewProject.Models {
    // Basic data frame for a periodic numeric sensor
    // Used generics to switch between different number types as necessary.
    public struct NumericFrame<T> {
        public T Value { get; }
        public T Err { get; }

        public NumericFrame(T value, T err){
            this.Value = value;
            this.Err = err;
        }

        public override string ToString() => $"{this.Value}+/-{this.Err}";
    }

    // Basic data frame for a aperiodic numeric sensor
    // Used generics to switch between different number types as necessary.
    public struct DataFrame<X,Y> {
        public X IndependentVar { get; }
        public Y DependentVar { get; }
        public DataFrame(X independentVar, Y dependentVar){
            this.IndependentVar = independentVar;
            this.DependentVar = dependentVar;
        }

        public override string ToString() => $"({this.IndependentVar},{this.DependentVar})";
    }
}