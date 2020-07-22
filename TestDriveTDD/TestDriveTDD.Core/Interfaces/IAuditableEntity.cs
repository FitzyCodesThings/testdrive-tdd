using System;
using System.Collections.Generic;
using System.Text;

namespace TestDriveTDD.Core.Interfaces
{
    public interface IAuditableEntity
    {
        public Guid ID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
