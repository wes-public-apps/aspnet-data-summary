using System.Collections.Generic;
using DataReviewProject.Models.MetaDataModels;

namespace DataReviewProject.Views.ViewModels{
    public struct CheckableItem<T>{
        public T Item {get;set;}
        public bool IsChecked {get;set;}
        public CheckableItem(T item){
            this.Item=item;
            this.IsChecked=false;
        }
        public CheckableItem(T item,bool isChecked){
            this.Item=item;
            this.IsChecked=isChecked;
        }
    }

    public class CreateHardwareViewModel{
        public HardwareMetaData HardwareMetaData {get;set;}
    }

    public class SensorGroupViewModel{
        public SensorGroupMetaData SensorGroupMetaData {get;set;}
        public List<CheckableItem<HardwareMetaData>> Hardware {get;set;}
    }
}