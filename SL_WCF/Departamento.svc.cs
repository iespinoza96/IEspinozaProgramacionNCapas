using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Departamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Departamento.svc or Departamento.svc.cs at the Solution Explorer and start debugging.
    public class Departamento : IDepartamento
    {
      
        public SL_WCF.Result AddEF(ML.Departamento departamento)
        {
            ML.Result resultDepartamento = BL.Departamento.AddEF(departamento);
            return new Result { Correct = resultDepartamento.Correct, ErrorMessage = resultDepartamento.ErrorMessage, Ex = resultDepartamento.Ex };
        }

        public SL_WCF.Result UpdateEF(ML.Departamento departamento)
        {
            ML.Result resultDepartamento = BL.Departamento.UpdateEF(departamento);
            return new Result { Correct = resultDepartamento.Correct, ErrorMessage = resultDepartamento.ErrorMessage, Ex = resultDepartamento.Ex };
        }

        public SL_WCF.Result DeleteEF(int IdDepartamento)
        {
            ML.Result resultDepartamento = BL.Departamento.DeleteEF(IdDepartamento);
            return new Result { Correct = resultDepartamento.Correct, ErrorMessage = resultDepartamento.ErrorMessage, Ex = resultDepartamento.Ex };
        }

        public SL_WCF.Result GetAllEF()
        {
            ML.Result resultDepartamento = BL.Departamento.GetAllEF();
            return new Result { Correct = resultDepartamento.Correct, ErrorMessage = resultDepartamento.ErrorMessage, Ex = resultDepartamento.Ex, Objects = resultDepartamento.Objects };
        }

        public SL_WCF.Result GetByIdEF(int IdDepartamento)
        {
            ML.Result resultDepartamento = BL.Departamento.GetByIdEF(IdDepartamento);
            return new Result { Correct = resultDepartamento.Correct, ErrorMessage = resultDepartamento.ErrorMessage, Ex = resultDepartamento.Ex, Object = resultDepartamento.Object };

        }

       
    }
}
