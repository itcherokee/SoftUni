﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DistanceCalculatorSoapClient.ServiceCalcDIstance {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Point", Namespace="http://schemas.datacontract.org/2004/07/DistanceCalculatorSoapService")]
    [System.SerializableAttribute()]
    public partial class Point : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int XField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int YField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int X {
            get {
                return this.XField;
            }
            set {
                if ((this.XField.Equals(value) != true)) {
                    this.XField = value;
                    this.RaisePropertyChanged("X");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Y {
            get {
                return this.YField;
            }
            set {
                if ((this.YField.Equals(value) != true)) {
                    this.YField = value;
                    this.RaisePropertyChanged("Y");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceCalcDIstance.ICalcDistance")]
    public interface ICalcDistance {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalcDistance/CalculateDistance", ReplyAction="http://tempuri.org/ICalcDistance/CalculateDistanceResponse")]
        double CalculateDistance(DistanceCalculatorSoapClient.ServiceCalcDIstance.Point startPoint, DistanceCalculatorSoapClient.ServiceCalcDIstance.Point endPoint);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalcDistance/CalculateDistance", ReplyAction="http://tempuri.org/ICalcDistance/CalculateDistanceResponse")]
        System.Threading.Tasks.Task<double> CalculateDistanceAsync(DistanceCalculatorSoapClient.ServiceCalcDIstance.Point startPoint, DistanceCalculatorSoapClient.ServiceCalcDIstance.Point endPoint);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalcDistanceChannel : DistanceCalculatorSoapClient.ServiceCalcDIstance.ICalcDistance, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalcDistanceClient : System.ServiceModel.ClientBase<DistanceCalculatorSoapClient.ServiceCalcDIstance.ICalcDistance>, DistanceCalculatorSoapClient.ServiceCalcDIstance.ICalcDistance {
        
        public CalcDistanceClient() {
        }
        
        public CalcDistanceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalcDistanceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalcDistanceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalcDistanceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double CalculateDistance(DistanceCalculatorSoapClient.ServiceCalcDIstance.Point startPoint, DistanceCalculatorSoapClient.ServiceCalcDIstance.Point endPoint) {
            return base.Channel.CalculateDistance(startPoint, endPoint);
        }
        
        public System.Threading.Tasks.Task<double> CalculateDistanceAsync(DistanceCalculatorSoapClient.ServiceCalcDIstance.Point startPoint, DistanceCalculatorSoapClient.ServiceCalcDIstance.Point endPoint) {
            return base.Channel.CalculateDistanceAsync(startPoint, endPoint);
        }
    }
}