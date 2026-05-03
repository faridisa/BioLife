using System;
using System.Collections.Generic;
using System.Text;

namespace BioLife.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
