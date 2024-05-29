using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Enums
{
    public enum ContractTypeEnum
    {
        [Description("Júnior")]
        Junior,

        [Description("Pleno")]
        MidLevel,

        [Description("Sênior")]
        Senior,

        [Description("Especialista")]
        Specialist
    }
}
