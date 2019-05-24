using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public abstract class SoftDeleteEntityBase : EntityBase
    {
        public bool IsDeleted { get; set; }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
