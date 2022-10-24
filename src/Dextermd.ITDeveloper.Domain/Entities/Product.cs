using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextermd.ITDeveloper.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        [Display(Name = "Product ID")]
        public Guid Id { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Field {0} не должно быть пустым!")]
        [StringLength(80, ErrorMessage = "Поле {0} должно содержать от {2} до {1} символа", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле {0} не должно быть пустым!")]
        [Range(0, 4000, ErrorMessage = "Поле {0} должно быть между {1} и {2}")]
        public decimal Price { get; set; } = 0;
        public int Stock { get; set; }

        [Display(Name = "Expiration Date", Description = "Выберите текущую или прошлую дату регистрации!")]
        [DataType(DataType.Date, ErrorMessage = "Недействительная дата"), DisplayFormat(DataFormatString = "{0:dd/MM//yyyy HH:mm}")]
        public DateTime ExpirationDate { get; set; }
        public bool InStock { get; set; } = true;
}
}
