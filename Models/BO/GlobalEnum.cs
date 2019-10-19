using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApi_ADO_DotNet.Models.BO
{
    public class GlobalEnum
    {
        #region  Operation
        enum EnumDBOperation
        {
            None = 0,Insert=1, Update = 2, Delete = 3, Approved = 4

        }
        #endregion
    }
}
