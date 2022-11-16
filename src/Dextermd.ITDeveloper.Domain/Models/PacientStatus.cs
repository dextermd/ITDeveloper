using Dextermd.ITDeveloper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextermd.ITDeveloper.Domain.Models
{
    public class PacientStatus : EntityBase
    {
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения")]
        [StringLength(maximumLength: 20, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символ(a).", MinimumLength = 2)]
        public string Description { get; set; }
    }
}
