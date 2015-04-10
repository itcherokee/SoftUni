using System.Runtime.Serialization;
using System.ServiceModel;

namespace DistanceCalculatorSoapService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICalcDistance
    {
        [OperationContract]
        double CalculateDistance(Point startPoint, Point endPoint);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Point
    {
        [DataMember]
        public int X { get; set; }

        [DataMember]
        public int Y { get; set; }
    }
}
