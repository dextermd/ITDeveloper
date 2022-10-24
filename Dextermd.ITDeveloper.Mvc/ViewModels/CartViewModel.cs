using Dextermd.ITDeveloper.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Dextermd.ITDeveloper.Mvc.ViewModels
{
    public class CartViewModel
    {
        public IList<Product> Products { get; set; }

        [Required]
        [Range(50, 4000, ErrorMessage = "Поле {0} должно быть между {1} и {2}")]
        public decimal TotalCartPrice { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "Поле {0} должно содержать от {2} до {1} символа", MinimumLength = 4)]
        public string Message { get; set; }
    }
}
