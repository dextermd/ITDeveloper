using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextermd.ITDeveloper.Domain.Enums
{
    public enum TypePacientInput
    {
        [Description("Hospitalization")] Hospitalization = 1,
        [Description("Emergency")] Emergency,
        [Description("Transfer")] Transfer,
        [Description("Ambulatory")] Ambulatory,
        [Description("No medical record")] NoMedicalRecord
    }
}
