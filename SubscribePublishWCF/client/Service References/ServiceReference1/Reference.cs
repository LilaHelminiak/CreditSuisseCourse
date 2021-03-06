﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MarketData", Namespace="http://schemas.datacontract.org/2004/07/Common")]
    [System.SerializableAttribute()]
    public partial class MarketData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double StockPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime businessDateField;
        
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
        public double StockPrice {
            get {
                return this.StockPriceField;
            }
            set {
                if ((this.StockPriceField.Equals(value) != true)) {
                    this.StockPriceField = value;
                    this.RaisePropertyChanged("StockPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime businessDate {
            get {
                return this.businessDateField;
            }
            set {
                if ((this.businessDateField.Equals(value) != true)) {
                    this.businessDateField = value;
                    this.RaisePropertyChanged("businessDate");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.ServiceModel.Samples", ConfigurationName="ServiceReference1.ISampleContract", CallbackContract=typeof(ServiceReference1.ISampleContractCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface ISampleContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/ISampleContract/Subscribe", ReplyAction="http://Microsoft.ServiceModel.Samples/ISampleContract/SubscribeResponse")]
        void Subscribe();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, Action="http://Microsoft.ServiceModel.Samples/ISampleContract/Unsubscribe", ReplyAction="http://Microsoft.ServiceModel.Samples/ISampleContract/UnsubscribeResponse")]
        void Unsubscribe();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Microsoft.ServiceModel.Samples/ISampleContract/PublishPriceChange")]
        void PublishPriceChange(ServiceReference1.MarketData newData);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISampleContractCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Microsoft.ServiceModel.Samples/ISampleContract/PriceChange")]
        void PriceChange(ServiceReference1.MarketData newData);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISampleContractChannel : ServiceReference1.ISampleContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SampleContractClient : System.ServiceModel.DuplexClientBase<ServiceReference1.ISampleContract>, ServiceReference1.ISampleContract {
        
        public SampleContractClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public SampleContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public SampleContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public SampleContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public SampleContractClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Subscribe() {
            base.Channel.Subscribe();
        }
        
        public void Unsubscribe() {
            base.Channel.Unsubscribe();
        }
        
        public void PublishPriceChange(ServiceReference1.MarketData newData) {
            base.Channel.PublishPriceChange(newData);
        }
    }
}
