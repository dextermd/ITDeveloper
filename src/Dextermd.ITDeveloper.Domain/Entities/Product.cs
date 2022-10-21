using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextermd.ITDeveloper.Domain.Entities
{
    public class Product
    {
        public Product()
        {

        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int Stock { get; set; }
    }
}
