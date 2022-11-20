using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextermd.ITDeveloper.Domain.Enums
{
    public enum TypePatientDischarge
    {
        [Description("Was discharged")] Discharged = 1,
        [Description("Transferred")] Transfer,
        [Description("Out by default")] OutDefault,
        [Description("Came to death")] Death, Others
    }
}
