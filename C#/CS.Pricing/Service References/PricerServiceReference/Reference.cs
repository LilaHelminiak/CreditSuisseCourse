﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CS.Pricing.PricerServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="PricerServiceLibrary", ConfigurationName="PricerServiceReference.IPricerContract", CallbackContract=typeof(CS.Pricing.PricerServiceReference.IPricerContractCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IPricerContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="PricerServiceLibrary/IPricerContract/Subscribe", ReplyAction="PricerServiceLibrary/IPricerContract/SubscribeResponse")]
        void Subscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="PricerServiceLibrary/IPricerContract/Subscribe", ReplyAction="PricerServiceLibrary/IPricerContract/SubscribeResponse")]
        System.Threading.Tasks.Task SubscribeAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, Action="PricerServiceLibrary/IPricerContract/Unsubscribe", ReplyAction="PricerServiceLibrary/IPricerContract/UnsubscribeResponse")]
        void Unsubscribe();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, Action="PricerServiceLibrary/IPricerContract/Unsubscribe", ReplyAction="PricerServiceLibrary/IPricerContract/UnsubscribeResponse")]
        System.Threading.Tasks.Task UnsubscribeAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="PricerServiceLibrary/IPricerContract/PublishUIData")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CS.Pricing.OptionResult[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CS.Pricing.OptionResult))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CS.Pricing.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CS.Trades.TradeTypes.OptionContract))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CS.Trades.TradeTypes.OptionContract.Type))]
        void PublishUIData(CS.Pricing.OptionData optionData);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="PricerServiceLibrary/IPricerContract/PublishUIData")]
        System.Threading.Tasks.Task PublishUIDataAsync(CS.Pricing.OptionData optionData);
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, Action="PricerServiceLibrary/IPricerContract/AddNewOption", ReplyAction="PricerServiceLibrary/IPricerContract/AddNewOptionResponse")]
        void AddNewOption(CS.Trades.TradeTypes.OptionContract optionData);
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, Action="PricerServiceLibrary/IPricerContract/AddNewOption", ReplyAction="PricerServiceLibrary/IPricerContract/AddNewOptionResponse")]
        System.Threading.Tasks.Task AddNewOptionAsync(CS.Trades.TradeTypes.OptionContract optionData);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPricerContractCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="PricerServiceLibrary/IPricerContract/GetPricerData")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CS.Pricing.OptionResult[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CS.Pricing.OptionResult))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CS.Pricing.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CS.Trades.TradeTypes.OptionContract))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CS.Trades.TradeTypes.OptionContract.Type))]
        void GetPricerData(CS.Pricing.OptionData newData);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPricerContractChannel : CS.Pricing.PricerServiceReference.IPricerContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PricerContractClient : System.ServiceModel.DuplexClientBase<CS.Pricing.PricerServiceReference.IPricerContract>, CS.Pricing.PricerServiceReference.IPricerContract {
        
        public PricerContractClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public PricerContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public PricerContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public PricerContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public PricerContractClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Subscribe() {
            base.Channel.Subscribe();
        }
        
        public System.Threading.Tasks.Task SubscribeAsync() {
            return base.Channel.SubscribeAsync();
        }
        
        public void Unsubscribe() {
            base.Channel.Unsubscribe();
        }
        
        public System.Threading.Tasks.Task UnsubscribeAsync() {
            return base.Channel.UnsubscribeAsync();
        }
        
        public void PublishUIData(CS.Pricing.OptionData optionData) {
            base.Channel.PublishUIData(optionData);
        }
        
        public System.Threading.Tasks.Task PublishUIDataAsync(CS.Pricing.OptionData optionData) {
            return base.Channel.PublishUIDataAsync(optionData);
        }
        
        public void AddNewOption(CS.Trades.TradeTypes.OptionContract optionData) {
            base.Channel.AddNewOption(optionData);
        }
        
        public System.Threading.Tasks.Task AddNewOptionAsync(CS.Trades.TradeTypes.OptionContract optionData) {
            return base.Channel.AddNewOptionAsync(optionData);
        }
    }
}
