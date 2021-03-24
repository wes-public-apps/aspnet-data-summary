using DataReviewProject.Utils.Types;

namespace DataReviewProject.Models {
    public class UAV : Labeled
    {
        #region Properties
        public string Id {get;set;}
        public StatusTypes Status {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        #endregion

        #region Constructors
        //Serialization Constructor
        public UAV(){}
        public UAV(string id,StatusTypes status,string name,string description){
            this.Id=id;
            this.Status=status;
            this.Name=name;
            this.Description=description;
        }
        #endregion
    }
}