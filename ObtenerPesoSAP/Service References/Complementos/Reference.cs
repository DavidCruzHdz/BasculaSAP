﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ObtenerPesoSAP.Complementos {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://cydsa.com/PL/TM/TM101/Sender/WebServices/PesoVehiculo_BasculaComplemeto", ConfigurationName="Complementos.SI_OS_BasculaComplemento")]
    public interface SI_OS_BasculaComplemento {
        
        // CODEGEN: Generating message contract since the operation SI_OS_BasculaComplemento is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://sap.com/xi/WebService/soap1.1", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ObtenerPesoSAP.Complementos.SI_OS_BasculaComplementoResponse SI_OS_BasculaComplemento(ObtenerPesoSAP.Complementos.SI_OS_BasculaComplementoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sap.com/xi/WebService/soap1.1", ReplyAction="*")]
        System.Threading.Tasks.Task<ObtenerPesoSAP.Complementos.SI_OS_BasculaComplementoResponse> SI_OS_BasculaComplementoAsync(ObtenerPesoSAP.Complementos.SI_OS_BasculaComplementoRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://cydsa.com/PL/TM/TM101/Sender/WebServices/PesoVehiculo_BasculaComplemeto")]
    public partial class DT_Bascula_ComplementoREQ : object, System.ComponentModel.INotifyPropertyChanged {
        
        private DT_Bascula_ComplementoREQData dataField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public DT_Bascula_ComplementoREQData data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
                this.RaisePropertyChanged("data");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://cydsa.com/PL/TM/TM101/Sender/WebServices/PesoVehiculo_BasculaComplemeto")]
    public partial class DT_Bascula_ComplementoREQData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string transporteField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string Transporte {
            get {
                return this.transporteField;
            }
            set {
                this.transporteField = value;
                this.RaisePropertyChanged("Transporte");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://cydsa.com/PL/TM/TM101/Sender/WebServices/PesoVehiculo_BasculaComplemeto")]
    public partial class DT_Bascula_ComplementoRES : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string nOM_TRANSPORTISTAField;
        
        private string fECHA_PLANField;
        
        private DT_Bascula_ComplementoRESItem[] cLIENTESField;
        
        private string rESULTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string NOM_TRANSPORTISTA {
            get {
                return this.nOM_TRANSPORTISTAField;
            }
            set {
                this.nOM_TRANSPORTISTAField = value;
                this.RaisePropertyChanged("NOM_TRANSPORTISTA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string FECHA_PLAN {
            get {
                return this.fECHA_PLANField;
            }
            set {
                this.fECHA_PLANField = value;
                this.RaisePropertyChanged("FECHA_PLAN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public DT_Bascula_ComplementoRESItem[] CLIENTES {
            get {
                return this.cLIENTESField;
            }
            set {
                this.cLIENTESField = value;
                this.RaisePropertyChanged("CLIENTES");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string RESULT {
            get {
                return this.rESULTField;
            }
            set {
                this.rESULTField = value;
                this.RaisePropertyChanged("RESULT");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://cydsa.com/PL/TM/TM101/Sender/WebServices/PesoVehiculo_BasculaComplemeto")]
    public partial class DT_Bascula_ComplementoRESItem : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string nUM_CLIENTEField;
        
        private string nOM_CLIENTEField;
        
        private string pOBLACIONField;
        
        private string rEGIONField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string NUM_CLIENTE {
            get {
                return this.nUM_CLIENTEField;
            }
            set {
                this.nUM_CLIENTEField = value;
                this.RaisePropertyChanged("NUM_CLIENTE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string NOM_CLIENTE {
            get {
                return this.nOM_CLIENTEField;
            }
            set {
                this.nOM_CLIENTEField = value;
                this.RaisePropertyChanged("NOM_CLIENTE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string POBLACION {
            get {
                return this.pOBLACIONField;
            }
            set {
                this.pOBLACIONField = value;
                this.RaisePropertyChanged("POBLACION");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string REGION {
            get {
                return this.rEGIONField;
            }
            set {
                this.rEGIONField = value;
                this.RaisePropertyChanged("REGION");
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
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SI_OS_BasculaComplementoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://cydsa.com/PL/TM/TM101/Sender/WebServices/PesoVehiculo_BasculaComplemeto", Order=0)]
        public ObtenerPesoSAP.Complementos.DT_Bascula_ComplementoREQ MT_Bascula_ComplementoREQ;
        
        public SI_OS_BasculaComplementoRequest() {
        }
        
        public SI_OS_BasculaComplementoRequest(ObtenerPesoSAP.Complementos.DT_Bascula_ComplementoREQ MT_Bascula_ComplementoREQ) {
            this.MT_Bascula_ComplementoREQ = MT_Bascula_ComplementoREQ;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SI_OS_BasculaComplementoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://cydsa.com/PL/TM/TM101/Sender/WebServices/PesoVehiculo_BasculaComplemeto", Order=0)]
        public ObtenerPesoSAP.Complementos.DT_Bascula_ComplementoRES MT_Bascula_ComplementoRES;
        
        public SI_OS_BasculaComplementoResponse() {
        }
        
        public SI_OS_BasculaComplementoResponse(ObtenerPesoSAP.Complementos.DT_Bascula_ComplementoRES MT_Bascula_ComplementoRES) {
            this.MT_Bascula_ComplementoRES = MT_Bascula_ComplementoRES;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SI_OS_BasculaComplementoChannel : ObtenerPesoSAP.Complementos.SI_OS_BasculaComplemento, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SI_OS_BasculaComplementoClient : System.ServiceModel.ClientBase<ObtenerPesoSAP.Complementos.SI_OS_BasculaComplemento>, ObtenerPesoSAP.Complementos.SI_OS_BasculaComplemento {
        
        public SI_OS_BasculaComplementoClient() {
        }
        
        public SI_OS_BasculaComplementoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SI_OS_BasculaComplementoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SI_OS_BasculaComplementoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SI_OS_BasculaComplementoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ObtenerPesoSAP.Complementos.SI_OS_BasculaComplementoResponse ObtenerPesoSAP.Complementos.SI_OS_BasculaComplemento.SI_OS_BasculaComplemento(ObtenerPesoSAP.Complementos.SI_OS_BasculaComplementoRequest request) {
            return base.Channel.SI_OS_BasculaComplemento(request);
        }
        
        public ObtenerPesoSAP.Complementos.DT_Bascula_ComplementoRES SI_OS_BasculaComplemento(ObtenerPesoSAP.Complementos.DT_Bascula_ComplementoREQ MT_Bascula_ComplementoREQ) {
            ObtenerPesoSAP.Complementos.SI_OS_BasculaComplementoRequest inValue = new ObtenerPesoSAP.Complementos.SI_OS_BasculaComplementoRequest();
            inValue.MT_Bascula_ComplementoREQ = MT_Bascula_ComplementoREQ;
            ObtenerPesoSAP.Complementos.SI_OS_BasculaComplementoResponse retVal = ((ObtenerPesoSAP.Complementos.SI_OS_BasculaComplemento)(this)).SI_OS_BasculaComplemento(inValue);
            return retVal.MT_Bascula_ComplementoRES;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ObtenerPesoSAP.Complementos.SI_OS_BasculaComplementoResponse> ObtenerPesoSAP.Complementos.SI_OS_BasculaComplemento.SI_OS_BasculaComplementoAsync(ObtenerPesoSAP.Complementos.SI_OS_BasculaComplementoRequest request) {
            return base.Channel.SI_OS_BasculaComplementoAsync(request);
        }
        
        public System.Threading.Tasks.Task<ObtenerPesoSAP.Complementos.SI_OS_BasculaComplementoResponse> SI_OS_BasculaComplementoAsync(ObtenerPesoSAP.Complementos.DT_Bascula_ComplementoREQ MT_Bascula_ComplementoREQ) {
            ObtenerPesoSAP.Complementos.SI_OS_BasculaComplementoRequest inValue = new ObtenerPesoSAP.Complementos.SI_OS_BasculaComplementoRequest();
            inValue.MT_Bascula_ComplementoREQ = MT_Bascula_ComplementoREQ;
            return ((ObtenerPesoSAP.Complementos.SI_OS_BasculaComplemento)(this)).SI_OS_BasculaComplementoAsync(inValue);
        }
    }
}
