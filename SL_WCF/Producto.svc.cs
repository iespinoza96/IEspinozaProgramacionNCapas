using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Producto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Producto.svc or Producto.svc.cs at the Solution Explorer and start debugging.
    public class Producto : IProducto
    {
        public SL_WCF.Result AddEF(ML.Producto producto)
        {
            ML.Result resultProducto = BL.Producto.AddEF(producto);
            return new Result { Correct = resultProducto.Correct, ErrorMessage = resultProducto.ErrorMessage, Ex = resultProducto.Ex };
        }

        public SL_WCF.Result UpdateEF(ML.Producto producto)
        {
            ML.Result resultProducto = BL.Producto.UpdateEF(producto);
            return new Result { Correct = resultProducto.Correct, ErrorMessage = resultProducto.ErrorMessage, Ex = resultProducto.Ex };
        }

        public SL_WCF.Result DeleteEF(ML.Producto producto)
        {
            ML.Result resultProducto = BL.Producto.DeleteEF(producto);
            return new Result { Correct = resultProducto.Correct, ErrorMessage = resultProducto.ErrorMessage, Ex = resultProducto.Ex };
        }

        public SL_WCF.Result GetAllEF()
        {
            ML.Result resultProducto = BL.Producto.GetAllEF();
            return new Result { Correct = resultProducto.Correct, ErrorMessage = resultProducto.ErrorMessage, Ex = resultProducto.Ex, Objects = resultProducto.Objects};
        }

        public SL_WCF.Result GetByIdEF(int IdProducto)
        {
            ML.Result resultProducto = BL.Producto.GetByIdEF(IdProducto);
            return new Result { Correct = resultProducto.Correct, ErrorMessage = resultProducto.ErrorMessage, Ex = resultProducto.Ex, Object = resultProducto.Object };

        }
    }
}
