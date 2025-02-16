﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace B2B.ServiceSalesOrder {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceSalesOrder.WebServiceSalesOrderSoap")]
    public interface WebServiceSalesOrderSoap {
        
        // CODEGEN: Generating message contract since message GetSalesOrderRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetSalesOrder", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        B2B.ServiceSalesOrder.GetSalesOrderResponse GetSalesOrder(B2B.ServiceSalesOrder.GetSalesOrderRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetSalesOrder", ReplyAction="*")]
        System.Threading.Tasks.Task<B2B.ServiceSalesOrder.GetSalesOrderResponse> GetSalesOrderAsync(B2B.ServiceSalesOrder.GetSalesOrderRequest request);
        
        // CODEGEN: Generating message contract since message GetOpenOrdersRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetOpenOrders", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        B2B.ServiceSalesOrder.GetOpenOrdersResponse GetOpenOrders(B2B.ServiceSalesOrder.GetOpenOrdersRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetOpenOrders", ReplyAction="*")]
        System.Threading.Tasks.Task<B2B.ServiceSalesOrder.GetOpenOrdersResponse> GetOpenOrdersAsync(B2B.ServiceSalesOrder.GetOpenOrdersRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class AuthHeader : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string usernameField;
        
        private string passwordField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
                this.RaisePropertyChanged("Username");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("Password");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
                this.RaisePropertyChanged("AnyAttr");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetSalesOrder", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetSalesOrderRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public B2B.ServiceSalesOrder.AuthHeader AuthHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string iv_vbeln;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string iv_kunnr;
        
        public GetSalesOrderRequest() {
        }
        
        public GetSalesOrderRequest(B2B.ServiceSalesOrder.AuthHeader AuthHeader, string iv_vbeln, string iv_kunnr) {
            this.AuthHeader = AuthHeader;
            this.iv_vbeln = iv_vbeln;
            this.iv_kunnr = iv_kunnr;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetSalesOrderResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetSalesOrderResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string GetSalesOrderResult;
        
        public GetSalesOrderResponse() {
        }
        
        public GetSalesOrderResponse(string GetSalesOrderResult) {
            this.GetSalesOrderResult = GetSalesOrderResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetOpenOrders", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetOpenOrdersRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public B2B.ServiceSalesOrder.AuthHeader AuthHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string[] lst_kunnr;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string iv_cmpt_abgru;
        
        public GetOpenOrdersRequest() {
        }
        
        public GetOpenOrdersRequest(B2B.ServiceSalesOrder.AuthHeader AuthHeader, string[] lst_kunnr, string iv_cmpt_abgru) {
            this.AuthHeader = AuthHeader;
            this.lst_kunnr = lst_kunnr;
            this.iv_cmpt_abgru = iv_cmpt_abgru;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetOpenOrdersResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetOpenOrdersResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string GetOpenOrdersResult;
        
        public GetOpenOrdersResponse() {
        }
        
        public GetOpenOrdersResponse(string GetOpenOrdersResult) {
            this.GetOpenOrdersResult = GetOpenOrdersResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebServiceSalesOrderSoapChannel : B2B.ServiceSalesOrder.WebServiceSalesOrderSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServiceSalesOrderSoapClient : System.ServiceModel.ClientBase<B2B.ServiceSalesOrder.WebServiceSalesOrderSoap>, B2B.ServiceSalesOrder.WebServiceSalesOrderSoap {
        
        public WebServiceSalesOrderSoapClient() {
        }
        
        public WebServiceSalesOrderSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServiceSalesOrderSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSalesOrderSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSalesOrderSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        B2B.ServiceSalesOrder.GetSalesOrderResponse B2B.ServiceSalesOrder.WebServiceSalesOrderSoap.GetSalesOrder(B2B.ServiceSalesOrder.GetSalesOrderRequest request) {
            return base.Channel.GetSalesOrder(request);
        }
        
        public string GetSalesOrder(B2B.ServiceSalesOrder.AuthHeader AuthHeader, string iv_vbeln, string iv_kunnr) {
            B2B.ServiceSalesOrder.GetSalesOrderRequest inValue = new B2B.ServiceSalesOrder.GetSalesOrderRequest();
            inValue.AuthHeader = AuthHeader;
            inValue.iv_vbeln = iv_vbeln;
            inValue.iv_kunnr = iv_kunnr;
            B2B.ServiceSalesOrder.GetSalesOrderResponse retVal = ((B2B.ServiceSalesOrder.WebServiceSalesOrderSoap)(this)).GetSalesOrder(inValue);
            return retVal.GetSalesOrderResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<B2B.ServiceSalesOrder.GetSalesOrderResponse> B2B.ServiceSalesOrder.WebServiceSalesOrderSoap.GetSalesOrderAsync(B2B.ServiceSalesOrder.GetSalesOrderRequest request) {
            return base.Channel.GetSalesOrderAsync(request);
        }
        
        public System.Threading.Tasks.Task<B2B.ServiceSalesOrder.GetSalesOrderResponse> GetSalesOrderAsync(B2B.ServiceSalesOrder.AuthHeader AuthHeader, string iv_vbeln, string iv_kunnr) {
            B2B.ServiceSalesOrder.GetSalesOrderRequest inValue = new B2B.ServiceSalesOrder.GetSalesOrderRequest();
            inValue.AuthHeader = AuthHeader;
            inValue.iv_vbeln = iv_vbeln;
            inValue.iv_kunnr = iv_kunnr;
            return ((B2B.ServiceSalesOrder.WebServiceSalesOrderSoap)(this)).GetSalesOrderAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        B2B.ServiceSalesOrder.GetOpenOrdersResponse B2B.ServiceSalesOrder.WebServiceSalesOrderSoap.GetOpenOrders(B2B.ServiceSalesOrder.GetOpenOrdersRequest request) {
            return base.Channel.GetOpenOrders(request);
        }
        
        public string GetOpenOrders(B2B.ServiceSalesOrder.AuthHeader AuthHeader, string[] lst_kunnr, string iv_cmpt_abgru) {
            B2B.ServiceSalesOrder.GetOpenOrdersRequest inValue = new B2B.ServiceSalesOrder.GetOpenOrdersRequest();
            inValue.AuthHeader = AuthHeader;
            inValue.lst_kunnr = lst_kunnr;
            inValue.iv_cmpt_abgru = iv_cmpt_abgru;
            B2B.ServiceSalesOrder.GetOpenOrdersResponse retVal = ((B2B.ServiceSalesOrder.WebServiceSalesOrderSoap)(this)).GetOpenOrders(inValue);
            return retVal.GetOpenOrdersResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<B2B.ServiceSalesOrder.GetOpenOrdersResponse> B2B.ServiceSalesOrder.WebServiceSalesOrderSoap.GetOpenOrdersAsync(B2B.ServiceSalesOrder.GetOpenOrdersRequest request) {
            return base.Channel.GetOpenOrdersAsync(request);
        }
        
        public System.Threading.Tasks.Task<B2B.ServiceSalesOrder.GetOpenOrdersResponse> GetOpenOrdersAsync(B2B.ServiceSalesOrder.AuthHeader AuthHeader, string[] lst_kunnr, string iv_cmpt_abgru) {
            B2B.ServiceSalesOrder.GetOpenOrdersRequest inValue = new B2B.ServiceSalesOrder.GetOpenOrdersRequest();
            inValue.AuthHeader = AuthHeader;
            inValue.lst_kunnr = lst_kunnr;
            inValue.iv_cmpt_abgru = iv_cmpt_abgru;
            return ((B2B.ServiceSalesOrder.WebServiceSalesOrderSoap)(this)).GetOpenOrdersAsync(inValue);
        }
    }
}
