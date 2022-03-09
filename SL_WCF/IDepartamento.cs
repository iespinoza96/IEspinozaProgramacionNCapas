using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDepartamento" in both code and config file together.
    [ServiceContract]
    public interface IDepartamento
    {

        [OperationContract]
        SL_WCF.Result AddEF(ML.Departamento departamento);

        [OperationContract]
        SL_WCF.Result UpdateEF(ML.Departamento departamento);

        [OperationContract]
        SL_WCF.Result DeleteEF(int IdDepartamento);

        [OperationContract]
        [ServiceKnownType (typeof(ML.Departamento))]
        SL_WCF.Result GetAllEF();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Departamento))]
        SL_WCF.Result GetByIdEF(int IdDepartamento);
    }
}
