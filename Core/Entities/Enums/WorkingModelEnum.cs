using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Enums
{
    public enum WorkingModelEnum
    {
        [Description("Remoto")]
        Remote,

        [Description("Híbrido")]
        Hybrid,

        [Description("Presencial")]
        InPerson
    }
}
