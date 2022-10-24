using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextermd.ITDeveloper.Domain.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }

           public Guid Id { get; set; }
    }
}
