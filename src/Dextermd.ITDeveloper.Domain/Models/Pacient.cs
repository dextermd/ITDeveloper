using Dextermd.ITDeveloper.Domain.Entities;
using Dextermd.ITDeveloper.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextermd.ITDeveloper.Domain.Models
{
    public class Pacient : EntityBase
    {

        public Pacient() { Active = true; }

        [ForeignKey("PacientStatus")]
        [Display(Name = "Pacient Status")]
        public Guid PacientStatusId { get; set; }
        public virtual PacientStatus? PacientStatus { get; set; }

        [DisplayName(displayName: "Pacient Name")]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HospitalizationDate { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string Cpf { get; set; }
        public TypePacient TypePacient { get; set; }
        public Sex Sex { get; set; }
        public string Rg { get; set; }
        public string RgOrgan { get; set; }
        public DateTime RgIssueDate { get; set; }

        public override string ToString()
        {
            return this.Id.ToString() + "  -  " + this.Name;
        }

    }
}
