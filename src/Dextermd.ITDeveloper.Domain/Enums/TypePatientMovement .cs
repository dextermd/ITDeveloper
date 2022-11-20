using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextermd.ITDeveloper.Domain.Enums
{
    public enum TypePatientMovement
    {
        [Description("Patient entry")] Entry = 1,
        [Description("Patient exit")] Exit
    }
}
