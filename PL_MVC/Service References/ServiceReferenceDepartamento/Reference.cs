﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL_MVC.ServiceReferenceDepartamento {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/SL_WCF")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Exception))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Departamento))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Area))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    public partial class Result : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool CorrectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Exception ExField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ObjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] ObjectsField;
        
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
        public bool Correct {
            get {
                return this.CorrectField;
            }
            set {
                if ((this.CorrectField.Equals(value) != true)) {
                    this.CorrectField = value;
                    this.RaisePropertyChanged("Correct");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Exception Ex {
            get {
                return this.ExField;
            }
            set {
                if ((object.ReferenceEquals(this.ExField, value) != true)) {
                    this.ExField = value;
                    this.RaisePropertyChanged("Ex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Object {
            get {
                return this.ObjectField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectField, value) != true)) {
                    this.ObjectField = value;
                    this.RaisePropertyChanged("Object");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] Objects {
            get {
                return this.ObjectsField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectsField, value) != true)) {
                    this.ObjectsField = value;
                    this.RaisePropertyChanged("Objects");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceDepartamento.IDepartamento")]
    public interface IDepartamento {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartamento/AddEF", ReplyAction="http://tempuri.org/IDepartamento/AddEFResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL_MVC.ServiceReferenceDepartamento.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        PL_MVC.ServiceReferenceDepartamento.Result AddEF(ML.Departamento departamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartamento/AddEF", ReplyAction="http://tempuri.org/IDepartamento/AddEFResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceReferenceDepartamento.Result> AddEFAsync(ML.Departamento departamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartamento/UpdateEF", ReplyAction="http://tempuri.org/IDepartamento/UpdateEFResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL_MVC.ServiceReferenceDepartamento.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        PL_MVC.ServiceReferenceDepartamento.Result UpdateEF(ML.Departamento departamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartamento/UpdateEF", ReplyAction="http://tempuri.org/IDepartamento/UpdateEFResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceReferenceDepartamento.Result> UpdateEFAsync(ML.Departamento departamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartamento/DeleteEF", ReplyAction="http://tempuri.org/IDepartamento/DeleteEFResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL_MVC.ServiceReferenceDepartamento.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        PL_MVC.ServiceReferenceDepartamento.Result DeleteEF(ML.Departamento departamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartamento/DeleteEF", ReplyAction="http://tempuri.org/IDepartamento/DeleteEFResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceReferenceDepartamento.Result> DeleteEFAsync(ML.Departamento departamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartamento/GetAllEF", ReplyAction="http://tempuri.org/IDepartamento/GetAllEFResponse")]
        PL_MVC.ServiceReferenceDepartamento.Result GetAllEF();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartamento/GetAllEF", ReplyAction="http://tempuri.org/IDepartamento/GetAllEFResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceReferenceDepartamento.Result> GetAllEFAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartamento/GetByIdEF", ReplyAction="http://tempuri.org/IDepartamento/GetByIdEFResponse")]
        PL_MVC.ServiceReferenceDepartamento.Result GetByIdEF(int IdDepartamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartamento/GetByIdEF", ReplyAction="http://tempuri.org/IDepartamento/GetByIdEFResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceReferenceDepartamento.Result> GetByIdEFAsync(int IdDepartamento);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDepartamentoChannel : PL_MVC.ServiceReferenceDepartamento.IDepartamento, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DepartamentoClient : System.ServiceModel.ClientBase<PL_MVC.ServiceReferenceDepartamento.IDepartamento>, PL_MVC.ServiceReferenceDepartamento.IDepartamento {
        
        public DepartamentoClient() {
        }
        
        public DepartamentoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DepartamentoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DepartamentoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DepartamentoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PL_MVC.ServiceReferenceDepartamento.Result AddEF(ML.Departamento departamento) {
            return base.Channel.AddEF(departamento);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceReferenceDepartamento.Result> AddEFAsync(ML.Departamento departamento) {
            return base.Channel.AddEFAsync(departamento);
        }
        
        public PL_MVC.ServiceReferenceDepartamento.Result UpdateEF(ML.Departamento departamento) {
            return base.Channel.UpdateEF(departamento);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceReferenceDepartamento.Result> UpdateEFAsync(ML.Departamento departamento) {
            return base.Channel.UpdateEFAsync(departamento);
        }
        
        public PL_MVC.ServiceReferenceDepartamento.Result DeleteEF(ML.Departamento departamento) {
            return base.Channel.DeleteEF(departamento);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceReferenceDepartamento.Result> DeleteEFAsync(ML.Departamento departamento) {
            return base.Channel.DeleteEFAsync(departamento);
        }
        
        public PL_MVC.ServiceReferenceDepartamento.Result GetAllEF() {
            return base.Channel.GetAllEF();
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceReferenceDepartamento.Result> GetAllEFAsync() {
            return base.Channel.GetAllEFAsync();
        }
        
        public PL_MVC.ServiceReferenceDepartamento.Result GetByIdEF(int IdDepartamento) {
            return base.Channel.GetByIdEF(IdDepartamento);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceReferenceDepartamento.Result> GetByIdEFAsync(int IdDepartamento) {
            return base.Channel.GetByIdEFAsync(IdDepartamento);
        }
    }
}
